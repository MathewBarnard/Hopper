using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld.RandomEncounters {
    public abstract class RandomEncounterGenerator {

        public abstract bool CheckForEncounter();

        public abstract bool CheckForEncounter(HexTile tile);
    }
}
