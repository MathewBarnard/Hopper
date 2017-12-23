using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities.AbilityResults {
    public class AbilityResult {

        private Combatant target;
        public Combatant Target {
            get { return target; }
        }
        private int result;
        public int Result {
            get { return result; }
        }

        public AbilityResult(Combatant target, int damageDealt) {
            this.target = target;
            this.result = damageDealt;
        }
    }
}
