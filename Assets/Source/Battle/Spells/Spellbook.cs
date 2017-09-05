using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells {
    public class Spellbook {

        private List<Ability> abilities;
        
        public List<Ability> All {
            get { return abilities; }
        }

        public Spellbook(string[] spells) {

            foreach(string spell in spells) {
                this.abilities.Add(CreateAbility(spell));
            }
        }

        public static Ability CreateAbility(string name) {

            switch(name.ToLower()) {
                case "attackmelee":
                    return new AttackMelee();
                default:
                    return null;
            }
        }
    }
}
