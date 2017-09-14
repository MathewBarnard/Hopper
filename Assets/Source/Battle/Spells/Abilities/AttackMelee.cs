using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Movement;
using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {
    public class AttackMelee : Ability {

        public AttackMelee() {

        }

        public AttackMelee(Combatant actingCombatant) {
            this.actingCombatant = actingCombatant;
        }

        public AttackMelee(Models.Ability abilityModel) {
            this.abilityType = Spells.AbilityType.attackmelee;
            this.targetingType = TargetingType.Single;
        }

        public override Type[] GetActions() {

            Type[] actions = new Type[4];

            actions[0] = typeof(MoveToCombatant);
            actions[1] = typeof(Actions.Attacks.AttackMelee);
            actions[2] = typeof(MoveToLocation);
            actions[3] = typeof(RotateToFace);

            return actions;
        }

        public override string Name() {
            return "attackmelee";
        }

        public override AbilityType AbilityType() {
            return Spells.AbilityType.attackmelee;
        }
    }
}
