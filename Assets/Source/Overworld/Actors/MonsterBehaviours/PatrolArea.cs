using Assets.Source.Overworld.Actors.ActorActions;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.MonsterBehaviours {
    public class PatrolArea : MonsterBehaviour {

        private HexTile destination;
        public int Range;

        public override HexTile NextDestination() {
            List<HexTile> neighbours = this.actor.InhabitedNode.TraversableNeighbours;

            this.destination = neighbours[UnityEngine.Random.Range(0, neighbours.Count - 1)];

            return destination;
        }
    }
}
