using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld {

    // Events handling occurances during the Overworld screen.
    public delegate void HexTileFocused(HexTile tile);
    public delegate void HexTileUnfocused(HexTile tile);
    public delegate void HexTileClicked(HexTile tile);

    public delegate void TravelStart(HexTile node);
    public delegate void ArrivedAtTile(HexTile node);

    public delegate void StartTurn();
    public delegate void AdvanceTurn();
    public delegate void ResolveTurn();

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
        public HexTileFocused onHexTileFocused;
        public HexTileUnfocused onHexTileUnfocused;

        // State changes
        public TravelStart onTravelStart;
        public ArrivedAtTile onArrivedAtTile;

        public StartTurn onStartTurn;
        public AdvanceTurn onAdvanceTurn;
        public ResolveTurn onResolveTurn;

        public void HexTileClicked(HexTile tile) {
            if (onHexTileClicked != null)
                onHexTileClicked.Invoke(tile);
        }

        public void HexTileFocused(HexTile tile) {
            if (onHexTileFocused != null)
                onHexTileFocused.Invoke(tile);
        }

        public void HexTileUnfocused(HexTile tile) {
            if (onHexTileUnfocused != null)
                onHexTileUnfocused.Invoke(tile);
        }

        public void TravelStart(HexTile tile) {
            if (onTravelStart != null)
                onTravelStart.Invoke(tile);
        }

        public void ArrivedAtTile(HexTile tile) {
            if (onArrivedAtTile != null)
                onArrivedAtTile.Invoke(tile);
        }

        public void StartTurn() {
            if (onStartTurn != null)
                onStartTurn.Invoke();
        }

        public void AdvanceTurn() {
            if (onAdvanceTurn != null)
                onAdvanceTurn.Invoke();
        }

        public void ResolveTurn() {
            if (onResolveTurn != null)
                onResolveTurn.Invoke();
        }
    }
}
