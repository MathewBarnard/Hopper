using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld {

    // Events handling occurances during the Overworld screen.
    public delegate void MapNodeClicked(MapNode node);

    public delegate void TravelStart(MapNode node);

    public class OverworldEventManager {

        private static OverworldEventManager overworldEventManager;

        public static OverworldEventManager Instance() {
            if (overworldEventManager == null) {
                overworldEventManager = new OverworldEventManager();
            }

            return overworldEventManager;
        }

        // User input
        public MapNodeClicked onMapNodeClicked;

        // State changes
        public TravelStart onTravelStart;

        public void MapNodeClicked(MapNode node) {
            if (onMapNodeClicked != null)
                onMapNodeClicked.Invoke(node);
        }

        public void TravelStart(MapNode node) {
            if (onTravelStart != null)
                onTravelStart.Invoke(node);
        }
    }
}
