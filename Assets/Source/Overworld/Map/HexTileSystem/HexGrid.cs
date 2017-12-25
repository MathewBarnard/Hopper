using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {

    public enum GridEditorMode { PLAY, EDIT };

    public class HexGrid : MonoBehaviour {

        public GridEditorMode gridEditorMode;

        private const int width = 10;
        private const int height = 10;

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

                    GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/BaseTile"), position, Quaternion.identity, this.transform);
                    tile.GetComponent<HexTile>().SetCoordinates(x, y);
                    tile.GetComponent<HexTile>().GridParent = this;
                    this.hexGrid.Add(tile.GetComponent<HexTile>());
                }
            }
        }

        private Vector2 GetTileSize() {
            // Create a throwaway tile so that we can get the dimensions of it.
            GameObject tile = Instantiate((GameObject)Resources.Load("Prefabs/Overworld/BaseTile"), Vector2.zero, Quaternion.identity, this.transform);
            SpriteRenderer renderer = tile.GetComponent<SpriteRenderer>();
            Vector2 spriteSize = renderer.sprite.bounds.size;
            Destroy(tile);
            return spriteSize;
        }

        public List<HexTile> GetAdjacentNodes(HexTile tileToCheck) {
            List<HexTile> adjacentTiles = new List<HexTile>();

            adjacentTiles = hexGrid.Where(tile =>
                                         (tile.Coordinates.x >= tileToCheck.Coordinates.x - 1 && tile.Coordinates.x <= tileToCheck.Coordinates.x + 1) &&
                                         (tile.Coordinates.y >= tileToCheck.Coordinates.y - 1 && tile.Coordinates.y <= tileToCheck.Coordinates.y + 1) &&
                                         (tile.Coordinates.z >= tileToCheck.Coordinates.z - 1 && tile.Coordinates.z <= tileToCheck.Coordinates.z + 1)).ToList();

            return adjacentTiles;
        }

        private void Update() {

            if(gridEditorMode == GridEditorMode.PLAY) {
                PlayMode();
            }
            else if(gridEditorMode == GridEditorMode.EDIT) {
                EditMode();
            }
        }

        private void PlayMode() {
            if (Input.GetKeyDown(KeyCode.Alpha9)) {

                Debug.Log("Edit Mode: On");

                if (hexGrid != null) {

                    HexTileEditor editor = hexGrid[0].GetComponent<HexTileEditor>();

                    foreach (HexTile tile in hexGrid) {
                        tile.gameObject.AddComponent<HexTileEditor>();
                    }
                }

                this.gridEditorMode = GridEditorMode.EDIT;
            }
        }

        private void EditMode() {

            if (Input.GetKeyDown(KeyCode.Alpha9)) {

                Debug.Log("Edit Mode: Off");

                if(hexGrid != null) {
                    foreach (HexTile tile in hexGrid) {
                        Destroy(tile.gameObject.GetComponent<HexTileEditor>());
                    }
                }

                this.gridEditorMode = GridEditorMode.PLAY;
            }

            if (Input.GetMouseButtonDown(0)) {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                Debug.Log(ray.origin);
                Debug.Log(ray.direction);

                if (hit.collider != null) {
                    // Store the tile to be destroyed
                    GameObject oldTile = hit.collider.gameObject;
                    HexTileEditor editor = oldTile.GetComponent<HexTileEditor>();

                    if (editor.index == editor.sprites.Length - 1)
                        editor.index = 0;
                    else
                        editor.index += 1;

                    // Create the new tile
                    GameObject newTile = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Overworld/{0}", editor.sprites[editor.index])), oldTile.transform.position, Quaternion.identity, this.transform);
                    newTile.GetComponent<HexTile>().SetCoordinates(oldTile.GetComponent<HexTile>().Coordinates);
                    newTile.GetComponent<HexTile>().GridParent = this;
                    HexTileEditor newEditor = newTile.AddComponent<HexTileEditor>();
                    newEditor.index = editor.index;

                    // Remove the old, add the new.
                    this.hexGrid.Remove(oldTile.GetComponent<HexTile>());
                    this.hexGrid.Add(newTile.GetComponent<HexTile>());

                    Destroy(oldTile);

                    Debug.Log(hexGrid.Count);
                }
            }
        }
    }
}
