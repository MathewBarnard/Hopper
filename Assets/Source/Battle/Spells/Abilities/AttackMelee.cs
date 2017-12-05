using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Miscellaneous;
using Assets.Source.Battle.Actions.Movement;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Battle.System;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {
    public class AttackMelee : Ability {

        public List<AbilityResult> damageDealt;

        private int physicalDamageModifier;

        public AttackMelee() {
            this.damageDealt = new List<AbilityResult>();
        }

        public AttackMelee(Combatant actingCombatant) {
            this.actingCombatant = actingCombatant;
        }

        public AttackMelee(Models.Ability abilityModel) {
            this.damageDealt = new List<AbilityResult>();
            this.abilityLevels = abilityModel.AbilityLevels;
            this.abilityType = Spells.AbilityType.attackmelee;
            this.targetingType = TargetingType.OFFENSIVE_SINGLE;
            this.physicalDamageModifier = 100;
            this.momentumApplied = 0;
        }

        public override void ApplyMomentum(int momentum) {

            AbilityLevel abilityLevel = this.abilityLevels.Where(al => al.Rank == momentum).FirstOrDefault();
            this.targetingType = abilityLevel.TargetingType;
            this.physicalDamageModifier = abilityLevel.PhysicalDamage;
        }

        public override Type[] GetActions() {

            Type[] actions = new Type[4];

            actions[0] = typeof(StepForward);
            actions[1] = typeof(Actions.Attacks.AttackMelee);
            actions[2] = typeof(StepBackward);
            actions[3] = typeof(TurnFinished);

            return actions;
        }

        public override string Name() {
            return "attackmelee";
        }

        public override AbilityType AbilityType() {
            return Spells.AbilityType.attackmelee;
        }

        // Processes the attack. The attack effect is modified by the number of momentum applied.
        public override void Process() {

            this.damageDealt.Clear();

            foreach(Combatant target in targets) {
                damageDealt.Add(DamageCalculator.CalculatePhysicalDamage(this.actingCombatant, target, this.physicalDamageModifier));
            }
        }

        public override void AttachScripts() {
            List<CombatAction> actionsToQueue = new List<CombatAction>();

            // Create each action
            actionsToQueue.Add(StepForward.CreateComponent(this.actingCombatant.gameObject, new UnityEngine.Vector3(-0.5f, 0.0f, 0.0f)));
            actionsToQueue.Add(Actions.Attacks.AttackMelee.CreateComponent(this.actingCombatant.gameObject, this.targets));
            actionsToQueue.Add(StepForward.CreateComponent(this.actingCombatant.gameObject, new UnityEngine.Vector3(0.0f, 0.0f, 0.0f)));
            actionsToQueue.Add(this.actingCombatant.gameObject.AddComponent<TurnFinished>());

            foreach (CombatAction combatAction in actionsToQueue) {

                // Each action has a reference to its source ability.
                combatAction.SetAbility(this);
            }

            this.actingCombatant.Actions.SetActions(actionsToQueue.ToArray());
        }
    }
}
