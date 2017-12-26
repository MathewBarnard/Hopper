using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld {

    // Events handling occurances during the Overworld screen.
    public delegate void HexTileClicked(HexTile tile);

    public delegate void TravelStart(HexTile node);
    public delegate void ArrivedAtTile(HexTile node);

    public class OverworldEventManager {

        private static OverworldEventManager overworldEventManager;

        public static OverworldEventManager Instance() {
            if (overworldEventManager == null) {
                overworldEventManager = new OverworldEventManager();
            }

            return overworldEventManager;
        }

        // User input
        public HexTileClicked onHexTileClicked;

        // State changes
        public TravelStart onTravelStart;
        public ArrivedAtTile onArrivedAtTile;

        public void HexTileClicked(HexTile tile) {
            if (onHexTileClicked != null)
                onHexTileClicked.Invoke(tile);
        }

        public void TravelStart(HexTile tile) {
            if (onTravelStart != null)
                onTravelStart.Invoke(tile);
        }

        public void ArrivedAtTile(HexTile tile) {
            if (onArrivedAtTile != null)
                onArrivedAtTile.Invoke(tile);
        }
    }
}
