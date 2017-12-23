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
        public PlayerParty playerActor;
        private MapNode destination;

        public void Awake() {
            this.overworldGameState = OverworldState.PLANNING;
            this.randomEncounterGenerator = new TimedEncounterGenerator(5.0f);
            OverworldEventManager.Instance().onMapNodeClicked += SetDestination;
            OverworldEventManager.Instance().onTravelStart += TravelStart;
        }

        public void Update() {
            if(this.overworldGameState == OverworldState.TRAVELLING && this.randomEncounterGenerator.CheckForEncounter()) {
                EngineEventManager.Instance().TransitionGameState(Engine.GameStates.Transitions.GameState.Battle, LoadSceneMode.Additive);
            }
        }

        public void SetDestination(MapNode node) {
            if(this.destination != null)
                this.destination.Deselect();

            this.destination = node;
            Debug.Log("Destination set!");
        }

        public void TravelCheck() {
            OverworldEventManager.Instance().TravelStart(this.destination);
        }

        public void TravelStart(MapNode node) {
            this.overworldGameState = OverworldState.TRAVELLING;
            this.playerActor.GetComponent<Engine.Actions.ActionQueue>().AddToFront(MoveToNode.CreateComponent(this.playerActor.gameObject, this.playerActor.InhabitedNode, node));
            Debug.Log("Travelling to destination!");
        }
    }
}
