using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.HexTileSystem {
    /// <summary>
    /// Controls vision of the map.
    /// </summary>
    public class FogOfWar : MonoBehaviour {

        public PlayerParty player;
        public HexGrid hexGrid;
        private List<HexTile> currentlyVisible;
        private float fadeAmount = 0.85f;

        public void Awake() {

            currentlyVisible = new List<HexTile>();
            OverworldEventManager.Instance().onArrivedAtTile += UpdateFog;
        }

        public void Start() {

            // Make all tiles invisible
            foreach(HexTile tile in hexGrid.Tiles) {
                ToggleTileAndActors(tile, fadeAmount);
            }
        }

        private void ToggleTileAndActors(HexTile tile, float fade) {

            tile.ToggleFade(fade);

            if (tile.inhabitingActor != null && !(tile.inhabitingActor is PlayerParty))
                tile.inhabitingActor.ToggleFade(fade);
        }

        public void RevealAll() {

            foreach(HexTile tile in this.hexGrid.Tiles) {
                ToggleTileAndActors(tile, 1.0f);
            }
        }

        public void HideAll() {
            foreach(HexTile tile in this.hexGrid.Tiles) {
                ToggleTileAndActors(tile, fadeAmount);
            }

            Reveal(player.InhabitedNode);
        }

        public void UpdateFog(HexTile tileArrivedAt) {

            Reveal(tileArrivedAt);
            Fade(tileArrivedAt);
            //Colour(tileArrivedAt);
        }

        private void Colour(HexTile tileArrivedAt) {
            tileArrivedAt.Colour(Color.green);

            foreach(HexTile tile in tileArrivedAt.Neighbours) {
                tile.Colour(Color.yellow);
            }
        }

        private void Reveal(HexTile tileArrivedAt) {
            // Get all hex tiles that are in range
            List<HexTile> tiles = hexGrid.GetTilesInRange(tileArrivedAt, 3);

            List<HexTile> visible = new List<HexTile>();

            // Test for obstacles
            foreach (HexTile tile in tiles) {

                Collider2D self = tile.Collider;

                // Should do this while we're travelling
                var hits = Physics2D.LinecastAll(tileArrivedAt.transform.position, tile.transform.position, 1 << LayerMask.NameToLayer("Traversable")).ToList();

                if (hits.Where(hit => hit.collider.gameObject.GetComponent<HexTile>().BlockLos && hit.collider != self).ToArray().Length == 0) {
                    visible.Add(tile);
                }
            }


            // Reveal remainder
            foreach (HexTile tile in visible) {
                ToggleTileAndActors(tile, 1.0f);
                tile.Discover();
            }

            // Store currently visible tiles
            this.currentlyVisible = visible;
        }

        private void Fade(HexTile tileArrivedAt) {

            List<HexTile> discoveredAndNotVisible = this.hexGrid.DiscoveredTiles.Where(t => this.currentlyVisible.Contains(t) == false).ToList();

            foreach(HexTile tile in discoveredAndNotVisible) {
                ToggleTileAndActors(tile, fadeAmount);
            }
        }
    }
}
