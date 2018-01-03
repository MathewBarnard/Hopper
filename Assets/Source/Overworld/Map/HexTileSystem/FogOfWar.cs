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

        public void Awake() {

            OverworldEventManager.Instance().onArrivedAtTile += Reveal;
        }

        public void Start() {

            // Make all tiles invisible
            foreach(HexTile tile in hexGrid.Tiles) {
                tile.ToggleVisiblity(false);
            }
        }

        public void Reveal(HexTile tileArrivedAt) {

            // Get all hex tiles that are in range
            List<HexTile> tiles = hexGrid.GetTilesInRange(tileArrivedAt, 3);

            List<HexTile> visible = new List<HexTile>();

            // Test for obstacles
            foreach(HexTile tile in tiles) {

                Collider2D self = tile.Collider;

                var hits = Physics2D.LinecastAll(tileArrivedAt.transform.position, tile.transform.position).ToList();

                if(hits.Where(hit => hit.collider.gameObject.GetComponent<HexTile>().BlockLos && hit.collider != self).ToArray().Length == 0) {
                    visible.Add(tile);
                } 
            }


            // Reveal remainder
            foreach(HexTile tile in visible) {
                tile.ToggleVisiblity(true);
            }
        }
    }
}
