using Assets.Source.Battle.Abilities.Abilities;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.Spells.Abilities.Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells {
    public class Spellbook {

        private List<AbilityGroup> abilitiesByGroup;

        public List<Ability> All {
            get 
            {
                List<Ability> abilities = new List<Ability>();

                foreach (AbilityGroup abilityGroup in abilitiesByGroup) 
                {
                    foreach(Ability ability in abilityGroup.abilities) {
                        abilities.Add(ability);
                    }
                }

                return abilities;
            }
        }

        public Spellbook(Combatant combatant, string[] spells) {

            this.abilitiesByGroup = new List<AbilityGroup>();

            //foreach (string abilityGroup in spells) {
            //    AbilityGroup ability = CreateAbility(spell);
            //    ability.ActingCombatant = combatant;
            //    this.abilities.Add(ability);
            //}
        }

        public Spellbook(Combatant combatant, List<Models.AbilityGroup> abilitiesByGroup) {

            this.abilitiesByGroup = new List<AbilityGroup>();

            foreach (Models.AbilityGroup abilityGroupModel in abilitiesByGroup) {
                List<Ability> abilitiesInGroup = new List<Ability>();

                foreach(Models.Ability abilityModel in abilityGroupModel.Abilities) {
                    Ability ability = CreateAbility(abilityModel);
                    ability.ActingCombatant = combatant;
                    abilitiesInGroup.Add(ability);
                }

                AbilityGroup abilityGroup = new AbilityGroup(abilitiesInGroup);

                this.abilitiesByGroup.Add(abilityGroup);
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
                    return new CustomAbility(ability);
            }
        }
    }


    public enum AbilityType {
        none,
        attackmelee,
        ember,
        knife_throw,
        knife_throw_debuff,
        knife_throw_all,
        knife_throw_debuff_all
    }

}
