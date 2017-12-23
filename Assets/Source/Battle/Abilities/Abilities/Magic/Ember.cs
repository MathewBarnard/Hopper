using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Battle.StateProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities.Magic {
    public class Ember : Ability {

        public Ember() {

        }

        public Ember(Models.Ability abilityModel) {

        }

        public override string Name() {
            return "ember";
        }

        public override AbilityType AbilityType() {
            return Spells.AbilityType.ember;
        }

        public override List<AbilityResult> Process(List<Combatant> targets) {
            throw new NotImplementedException();
        }

        public override void AttachScripts(AbilitySelection abilitySelection) {
            throw new NotImplementedException();
        }
    }
}
