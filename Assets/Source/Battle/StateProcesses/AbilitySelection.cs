using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.StateProcesses {
    public class AbilitySelection {
        public Combatant combatant;
        public Ability ability;
        public List<Combatant> targets;
        public List<AbilityResult> results;
    }
}
