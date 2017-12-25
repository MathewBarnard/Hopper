using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {

    public class HexGrid : MonoBehaviour {

        private const int width = 6;
        private const int height = 6;

        private List<HexTile> hexGrid;

        private void Awake() {

            this.hexGrid = new List<HexTile>();

            // Create a throwaway tile so that we can get the dimensions of it.
            Vector2 spriteSize = GetTileSize();

            // Y
            for (int y = 0; y < width; y++) {

                // X
                for (int x = 0; x < height; x++) {

                    float mod = y % 2;

                    Vector2 position = new Vector2((x * spriteSize.x) + ((spriteSize.x * 0.5f) * mod), (y * spriteSize.y) * 0.75f);

                    GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/BaseTileMountain"), position, Quaternion.identity, this.transform);
                    tile.GetComponent<HexTile>().SetCoordinates(x, y);
                    this.hexGrid.Add(tile.GetComponent<HexTile>());
                }
            }

            //foreach (HexTile tile in this.hexGrid) {
            //    tile.gameObject.transform.position = new Vector2(tile.gameObject.transform.position.x + (tile.gameObject.transform.position.y * 0.5f),
            //                                                    tile.gameObject.transform.position.y);
            //}
        }

        private Vector2 GetTileSize() {
            // Create a throwaway tile so that we can get the dimensions of it.
            GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/BaseTile"), Vector2.zero, Quaternion.identity, this.transform);
            SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
            Vector2 spriteSize = renderer.sprite.bounds.size;
            Destroy(tile);
            return spriteSize;
        }
    }
}
