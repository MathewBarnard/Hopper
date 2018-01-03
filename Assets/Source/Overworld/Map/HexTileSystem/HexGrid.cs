using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Map.MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {

    public enum GridEditorMode { PLAY, EDIT };

    public class HexGrid : MonoBehaviour {

        public GridEditorMode gridEditorMode;
        public string mapToLoad;

        public int width;
        public int height;

        private List<HexTile> tiles;
        public List<HexTile> Tiles {
            get { return tiles; }
        }
        
        public HexTile Origin {
            get { return tiles[0]; }
        }

        private HexTile centre;
        public HexTile Centre {
            get { return centre; }
        }

        private void Awake() {

            this.tiles = new List<HexTile>();

            if(string.IsNullOrEmpty(mapToLoad)) {
                HexGridGenerator.GenerateDefault(this, width, height);
            }
            else {
                HexGridGenerator.GenerateFromFile(this, mapToLoad);
            }

            // Set centre
            centre = tiles.Where(tile => tile.Coordinates.x == width / 2 && tile.Coordinates.y == height / 2).FirstOrDefault();
        }

        public List<HexTile> GetAdjacentNodes(HexTile tileToCheck) {
            List<HexTile> adjacentTiles = new List<HexTile>();

            adjacentTiles = tiles.Where(tile =>
                                         (tile.AxialCoordinates.x >= tileToCheck.AxialCoordinates.x - 1 && tile.AxialCoordinates.x <= tileToCheck.AxialCoordinates.x + 1) &&
                                         (tile.AxialCoordinates.y >= tileToCheck.AxialCoordinates.y - 1 && tile.AxialCoordinates.y <= tileToCheck.AxialCoordinates.y + 1) &&
                                         (tile.AxialCoordinates.z >= tileToCheck.AxialCoordinates.z - 1 && tile.AxialCoordinates.z <= tileToCheck.AxialCoordinates.z + 1)).ToList();

            return adjacentTiles;
        }

        public List<HexTile> GetTilesInRange(HexTile tile, int range) {

            return this.tiles.Where(t => (t.axialCoordinates.x >= tile.axialCoordinates.x - range && t.axialCoordinates.x <= tile.axialCoordinates.x + range) &&
                                         (t.axialCoordinates.y >= tile.axialCoordinates.y - range && t.axialCoordinates.y <= tile.axialCoordinates.y + range) &&
                                         (t.axialCoordinates.z >= tile.axialCoordinates.z - range && t.axialCoordinates.z <= tile.axialCoordinates.z + range)).ToList();
        }

        private void Update() {

            if(gridEditorMode == GridEditorMode.EDIT) {
                EditMode();
            }
        }

        public void AddHexEditor() {

            if (tiles != null) {

                HexTileEditor editor = tiles[0].GetComponent<HexTileEditor>();

                foreach (HexTile tile in tiles) {
                    tile.gameObject.AddComponent<HexTileEditor>();
                }
            }
        }

        public void RemoveHexEditor() {
            if (tiles != null) {
                foreach (HexTile tile in tiles) {
                    Destroy(tile.gameObject.GetComponent<HexTileEditor>());
                }
            }

        }

        private void EditMode() {

            if (Input.GetMouseButtonDown(0)) {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

                if (hit.collider != null) {

                    // Store the tile to be destroyed
                    GameObject oldTile = hit.collider.gameObject;
                    oldTile.GetComponent<HexTileEditor>().ChangeTile(this);
                }
            }

            // Saving current hex map
            if(Input.GetKeyDown(KeyCode.S)) {
                HexMapFileSaver.SaveFile(this.tiles);
            }
        }
    }
}
