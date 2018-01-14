using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Actors.ActorActions;
using Assets.Source.Overworld.Map;
using Assets.Source.Overworld.RandomEncounters;
using Assets.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Source.Overworld.Map.HexTileSystem;
using Assets.Source.Overworld.Map.MapEditor;
using Assets.Source.Overworld.Actors.MonsterBehaviours;
using Assets.Source.Overworld.Events;

namespace Assets.Source.Overworld {

    public enum OverworldState { PLANNING, TRAVELLING, EVENT, COMBAT }

    public class OverworldManager : MonoBehaviour {

        public GameObject sceneGrouper;

        private OverworldState overworldGameState;
        public HexGrid hexGrid;
        public FogOfWar fogOfWar;
        public MonsterManager monsterManager;

        // Turn management
        public PlayerParty playerActor;
        private Queue<HexTile> path;

        private Queue<TurnEvent> events;
        private TurnEvent currentEvent;

        public void Awake() {
            this.overworldGameState = OverworldState.PLANNING;

            // Delegate control of map loading to the OverworldManager. 
            List<HexMapCsv> file = null;

            // Load the default map
            if (string.IsNullOrEmpty(hexGrid.mapToLoad)) {
                HexGridGenerator.GenerateDefault(hexGrid, hexGrid.width, hexGrid.height);
            }
            // Load from file
            else {
                file = HexMapFileSaver.ReadFile(hexGrid.mapToLoad);
                HexGridGenerator.GenerateFromFile(hexGrid, file);
            }

            this.monsterManager.SetInitialSpawn(this.hexGrid, file);

            OverworldEventManager.Instance().onHexTileClicked += ProcessTileSelection;
        }

        public void ProcessTurn() {

            Debug.Log("PROCESSING TURN");
            this.events = new Queue<TurnEvent>();

            // Call this event so that subscribers can whip up a tasty treat for OverworldManager to consume
            OverworldEventManager.Instance().StartTurn();

            // STEP 1: Determine where all actors will end their turn
            HexTile playerDestination = path.Dequeue();

            List<MonsterParty> monstersWithSameDest = new List<MonsterParty>();

            // STEP 2: If a monster and player are going to inhabit the same node, then we should set up a contest action instead of a move
            foreach(MonsterParty monster in monsterManager.Monsters) {
                if(monster.Behaviours.NextDestination() == playerDestination) {
                    monstersWithSameDest.Add(monster);
                }
            }

            if(monstersWithSameDest.Count > 0) {
                // We would add conflict events 
            }

            // STEP 3: Once the player has dealt with all the baddies, we can move everyone else.
            List<KeyValuePair<Actor, HexTile>> actorsAndDestinations = new List<KeyValuePair<Actor, HexTile>>();
            actorsAndDestinations.Add(new KeyValuePair<Actor, HexTile>(playerActor, playerDestination));
            foreach (MonsterParty monster in monsterManager.Monsters) {
                actorsAndDestinations.Add(new KeyValuePair<Actor, HexTile>(monster, monster.Behaviours.NextDestination()));
            }

            this.events.Enqueue(new MoveAllActors(actorsAndDestinations));
        }

        public void ProcessTileSelection(HexTile node) {

            this.path = Pathfinder.BreadthFirstSearch(playerActor.InhabitedNode, node);

            ProcessTurn();

            //if (node.inhabitingActor == null) {
            //    this.playerActor.GetComponent<Engine.Actions.ActionQueue>().AddToFront(MoveToNode.CreateComponent(this.playerActor.gameObject, this.playerActor.InhabitedNode, node));
            //    Debug.Log("Travelling to destination!");
            //}
            //else {
            //    // Logic for happens when the actor is clicked is delegated to that actor.
            //    if(node.inhabitingActor is MonsterParty) {
            //        EngineEventManager.Instance().TransitionGameState(Engine.GameStates.Transitions.GameState.Battle, LoadSceneMode.Additive);
            //        Destroy(node.inhabitingActor.gameObject);
            //        node.inhabitingActor = null;
            //    }
            //}
        }

        public void Update() {

            // When no events are 
            if (events != null && currentEvent == null && events.Count > 0) {

                // Check if the event is still running
                if(currentEvent == null) {
                    currentEvent = events.Dequeue();
                    currentEvent.Go();
                }
            }
            else if(currentEvent != null) {
                if (currentEvent.IsComplete()) {
                    currentEvent = null;
                }
            }
            else {
                if(path != null && path.Count > 0) {
                    ProcessTurn();
                }
            }

            // Controls map edit mode.
            if(Input.GetKeyDown(KeyCode.Alpha9)) {

                if ((int)this.hexGrid.gridEditorMode == Enum.GetValues(typeof(GridEditorMode)).Length - 1)
                    this.hexGrid.gridEditorMode = 0;
                else
                    this.hexGrid.gridEditorMode += 1;

                if(this.hexGrid.gridEditorMode == GridEditorMode.PLAY) {
                    OverworldEventManager.Instance().onHexTileClicked += ProcessTileSelection;
                    this.hexGrid.RemoveHexEditor();
                    this.fogOfWar.HideAll();
                }
                else if(this.hexGrid.gridEditorMode == GridEditorMode.EDIT) {
                    OverworldEventManager.Instance().onHexTileClicked -= ProcessTileSelection;
                    this.hexGrid.AddHexEditor();
                    this.fogOfWar.RevealAll();
                }
            }
        }
    }
}
