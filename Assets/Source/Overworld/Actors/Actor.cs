using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors {
    public abstract class Actor : MonoBehaviour {

        private HexTile destination;
        private HexTile inhabitedNode;
        public HexTile InhabitedNode {
            get { return inhabitedNode; }
        }

        private void Update() {

        }
    }
}
