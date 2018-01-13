using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Actors.ActorActions;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld.Events {
    public class MoveAllActors : TurnEvent {

        private List<KeyValuePair<Actor, HexTile>> actorsToMove;

        public MoveAllActors(List<KeyValuePair<Actor, HexTile>> actorsToMove) {
            this.actorsToMove = actorsToMove;
        }

        public override void Go() {
            foreach (KeyValuePair<Actor, HexTile> pair in actorsToMove) {
                pair.Key.actionQueue.AddToFront(MoveToNode.Create(pair.Key, pair.Value));
            }
        }

        public override void Setup() {

        }
    }
}
