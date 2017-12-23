using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Abilities.Abilities {
    public class AbilityGroup {

        public List<Ability> abilities;

        public AbilityGroup(List<Ability> abilities) {
            this.abilities = abilities;
        }
    }
}
