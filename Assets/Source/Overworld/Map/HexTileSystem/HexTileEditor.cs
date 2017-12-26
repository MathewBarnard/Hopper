using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {
    public class HexTileEditor : MonoBehaviour {

        public string[] sprites = { "BaseTile", "BaseTileMountain", "BaseTileTown" };

        private TileType tileType;
        public int index = 0;
        private SpriteRenderer spriteRenderer;

        public void Awake() {
            this.tileType = this.gameObject.GetComponent<HexTile>().tileType;
        }

        public void ChangeTile(HexGrid grid) {

            if ((int)tileType == Enum.GetNames(typeof(TileType)).Length - 1)
                this.tileType = 0;
            else
                this.tileType += 1;

            // Create the new tile
            HexTile newTile = HexTile.Create(grid, tileType, transform.position, this.gameObject.GetComponent<HexTile>().Coordinates);
            HexTileEditor newEditor = newTile.gameObject.AddComponent<HexTileEditor>();
            newEditor.tileType = this.tileType;

            // Remove the old, add the new.
            grid.Tiles.Remove(this.gameObject.GetComponent<HexTile>());
            grid.Tiles.Add(newTile.GetComponent<HexTile>());

            Destroy(this.gameObject);
        }
    }
}
