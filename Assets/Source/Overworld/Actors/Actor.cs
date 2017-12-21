using Assets.Source.Dungeon.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Dungeon.Actors {
    public abstract class Actor : MonoBehaviour {

        private MapNode destination;
        private MapNode inhabitedNode;
        public MapNode InhabitedNode {
            get { return inhabitedNode; }
        }

        private void Update() {

        }
    }
}
