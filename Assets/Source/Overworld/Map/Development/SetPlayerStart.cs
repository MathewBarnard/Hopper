using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Actors.ActorActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.Development {

    public class SetPlayerStart : MonoBehaviour {

        public PlayerParty playerPartyActor;
        public HexGrid hexGrid;

        private void Start() {

            this.hexGrid.Origin.inhabitingActor = playerPartyActor;
            this.playerPartyActor.GetComponent<Engine.Actions.ActionQueue>().AddToFront(MoveToNode.CreateComponent(this.playerPartyActor.gameObject, this.hexGrid.Origin, this.hexGrid.Origin));
        }
    }
}
