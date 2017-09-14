using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.Spells.Abilities.Magic;
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

        public Spellbook(Combatant combatant, string[] spells) {

            this.abilities = new List<Ability>();

            foreach (string spell in spells) {
                Ability ability = CreateAbility(spell);
                ability.ActingCombatant = combatant;
                this.abilities.Add(ability);
            }
        }

        public Spellbook(Combatant combatant, List<Models.Ability> abilities) {

            this.abilities = new List<Ability>();

            foreach (Models.Ability abilityModel in abilities) {
                Ability ability = CreateAbility(abilityModel);
                ability.ActingCombatant = combatant;
                this.abilities.Add(ability);
            }
        }

        public static Ability CreateAbility(string name) {

            switch (name.ToLower()) {
                case "attackmelee":
                    return new AttackMelee();
                default:
                    return null;
            }
        }

        public static Ability CreateAbility(AbilityType abilityType) {

            switch(abilityType) {
                case AbilityType.attackmelee:
                    return new AttackMelee();
                default:
                    return null;
            }
        }

        public static Ability CreateAbility(Models.Ability ability) {

            switch (ability.Name.ToLower()) {
                case "attackmelee":
                    return new AttackMelee(ability);
                case "ember":
                    return new Ember(ability);
                default:
                    return null;
            }
        }
    }


    public enum AbilityType {
        none,
        attackmelee,
        ember
    }

}
