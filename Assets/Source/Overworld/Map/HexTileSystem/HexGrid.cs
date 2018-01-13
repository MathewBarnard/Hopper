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

        private HexTile[,] tilesArray;

        private List<HexTile> tiles;
        public List<HexTile> Tiles {
            get 
            {
                if (tiles == null)
                    tiles = new List<HexTile>();
                return tiles;
            }
        }

        public List<HexTile> DiscoveredTiles {
            get { return tiles.Where(t => t.Discovered == true).ToList(); }
        }

        
        public HexTile Origin {
            get { return tiles[0]; }
        }

        private HexTile centre;
        public HexTile Centre {
            get { return centre; }
        }

        public void StoreToArray() {
            tilesArray = new HexTile[width, height];

            // Store our tiles in a nice wee array
            foreach (HexTile tile in Tiles) {
                Vector2 offsetCoords = HexTile.CubeToOffset(tile.CubeCoordinates);
                tilesArray[(int)tile.OffsetCoordinates.x, (int)tile.OffsetCoordinates.y] = tile;
            }
        }

        private void Start() {

            // Set centre
            centre = tiles.Where(tile => tile.Coordinates.x == width / 2 && tile.Coordinates.y == height / 2).FirstOrDefault();
        }

        public List<HexTile> GetAdjacentNodes(HexTile tileToCheck) {
            List<HexTile> adjacentTiles = new List<HexTile>();

            adjacentTiles = tiles.Where(tile =>
                                         (tile.CubeCoordinates.x >= tileToCheck.CubeCoordinates.x - 1 && tile.CubeCoordinates.x <= tileToCheck.CubeCoordinates.x + 1) &&
                                         (tile.CubeCoordinates.y >= tileToCheck.CubeCoordinates.y - 1 && tile.CubeCoordinates.y <= tileToCheck.CubeCoordinates.y + 1) &&
                                         (tile.CubeCoordinates.z >= tileToCheck.CubeCoordinates.z - 1 && tile.CubeCoordinates.z <= tileToCheck.CubeCoordinates.z + 1)).ToList();

            adjacentTiles.Remove(tileToCheck);

            return adjacentTiles;
        }

        public List<HexTile> GetTilesInRange(HexTile tile, int range) {

            return this.tiles.Where(t => (t.CubeCoordinates.x >= tile.CubeCoordinates.x - range && t.CubeCoordinates.x <= tile.CubeCoordinates.x + range) &&
                                         (t.CubeCoordinates.y >= tile.CubeCoordinates.y - range && t.CubeCoordinates.y <= tile.CubeCoordinates.y + range) &&
                                         (t.CubeCoordinates.z >= tile.CubeCoordinates.z - range && t.CubeCoordinates.z <= tile.CubeCoordinates.z + range)).ToList();
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
