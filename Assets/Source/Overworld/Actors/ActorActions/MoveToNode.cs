using Assets.Source.Overworld.Map;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.ActorActions {
    public class MoveToNode : ActorAction {

        private HexTile origin;
        private HexTile destination;

        public static MoveToNode CreateComponent(GameObject objectToAttachTo, HexTile origin, HexTile destination) {
            MoveToNode action = objectToAttachTo.AddComponent<MoveToNode>();
            action.origin = origin;
            action.destination = destination;
        
            return action;
        }

        private void Update() {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.destination.transform.position, 0.5f * Time.deltaTime);
        }
    }
}
