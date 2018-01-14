using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Actors.ActorActions;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Events {
    public class MoveAllActors : TurnEvent {

        private List<MoveToNode> scripts;
        private List<KeyValuePair<Actor, HexTile>> actorsToMove;

        public MoveAllActors(List<KeyValuePair<Actor, HexTile>> actorsToMove) {
            this.actorsToMove = actorsToMove;
        }

        public override void Go() {
            scripts = new List<MoveToNode>();
            foreach (KeyValuePair<Actor, HexTile> pair in actorsToMove) {
                MoveToNode moveScript = MoveToNode.Create(pair.Key, pair.Value);
                scripts.Add(moveScript);
                pair.Key.actionQueue.AddToFront(moveScript);
            }
        }

        public override bool IsComplete() {
            foreach(MoveToNode script in scripts) {
                if (script != null)
                    return false;
            }

            Debug.Log("Event complete");
            return true;
        }
    }
}
