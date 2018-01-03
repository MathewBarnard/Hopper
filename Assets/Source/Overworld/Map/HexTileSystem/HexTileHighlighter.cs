using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.HexTileSystem {
    public class HexTileHighlighter : MonoBehaviour {

        private Vector3 offScreenPosition;

        public void Awake() {
            offScreenPosition = this.transform.position;
            OverworldEventManager.Instance().onHexTileFocused += MoveToTile;
            OverworldEventManager.Instance().onHexTileUnfocused += MoveOffScreen;
        }

        public void MoveToTile(HexTile tile) {
            this.transform.position = tile.transform.position;
        }

        public void MoveOffScreen(HexTile tile) {
            this.transform.position = offScreenPosition;
        }
    }
}
