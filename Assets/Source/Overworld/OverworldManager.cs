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

namespace Assets.Source.Overworld {

    public enum OverworldState { PLANNING, TRAVELLING, EVENT, COMBAT }

    public class OverworldManager : MonoBehaviour {

        public GameObject sceneGrouper;

        private OverworldState overworldGameState;
        public RandomEncounterGenerator randomEncounterGenerator;
        public HexGrid hexGrid;
        public PlayerParty playerActor;

        public void Awake() {
            this.overworldGameState = OverworldState.PLANNING;
            this.randomEncounterGenerator = new ArriveEncounterGenerator();
            OverworldEventManager.Instance().onHexTileClicked += TravelStart;
            OverworldEventManager.Instance().onArrivedAtTile += ProcessTileEvents;
        }

        public void TravelStart(HexTile node) {
            this.overworldGameState = OverworldState.TRAVELLING;
            this.playerActor.GetComponent<Engine.Actions.ActionQueue>().AddToFront(MoveToNode.CreateComponent(this.playerActor.gameObject, this.playerActor.InhabitedNode, node));
            Debug.Log("Travelling to destination!");
        }

        public void ProcessTileEvents(HexTile tile) {

            // Generate a random encounter.
            Debug.Log("Arrived!");
            
            if(this.randomEncounterGenerator.CheckForEncounter(tile)) {
                Debug.Log("Beginning encounter");
                EngineEventManager.Instance().TransitionGameState(Engine.GameStates.Transitions.GameState.Battle, LoadSceneMode.Additive);
            }
        }

        public void Update() {

            // Controls map edit mode.
            if(Input.GetKeyDown(KeyCode.Alpha9)) {

                if ((int)this.hexGrid.gridEditorMode == Enum.GetValues(typeof(GridEditorMode)).Length - 1)
                    this.hexGrid.gridEditorMode = 0;
                else
                    this.hexGrid.gridEditorMode += 1;

                if(this.hexGrid.gridEditorMode == GridEditorMode.PLAY) {
                    OverworldEventManager.Instance().onHexTileClicked += TravelStart;
                    this.hexGrid.RemoveHexEditor();
                }
                else if(this.hexGrid.gridEditorMode == GridEditorMode.EDIT) {
                    OverworldEventManager.Instance().onHexTileClicked -= TravelStart;
                    this.hexGrid.AddHexEditor();
                }
            }
        }
    }
}
