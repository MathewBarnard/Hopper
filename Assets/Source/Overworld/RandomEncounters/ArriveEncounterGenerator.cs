using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Source.Overworld.Map;

namespace Assets.Source.Overworld.RandomEncounters {

    public class ArriveEncounterGenerator : RandomEncounterGenerator {

        private int failedChecks;

        public ArriveEncounterGenerator() {
            failedChecks = 0;
        }

        public override bool CheckForEncounter() {
            throw new NotImplementedException();
        }

        public override bool CheckForEncounter(HexTile tile) {

            int random = UnityEngine.Random.Range((int)0, (int)10);

            if(random <= failedChecks) {
                failedChecks = 0;
                return true;
            }
            else {
                failedChecks += 1;
                return false;
            }
        }
    }
}