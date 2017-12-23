using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.System;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Engine.Actions;
using Assets.Source.Battle.Actions.Movement;
using Assets.Source.Battle.Actions.Miscellaneous;
using Assets.Source.Battle.StateProcesses;

namespace Assets.Source.Battle.Abilities.Abilities {
    public class CustomAbility : Ability {

        public CustomAbility(Models.Ability model) {
            this.model = model;
        }

        public override AbilityType AbilityType() {
            throw new NotImplementedException();
        }

        public override void AttachScripts(AbilitySelection abilitySelection) {

            List<ActorAction> actionsToQueue = new List<ActorAction>();

            // Create each action
            actionsToQueue.Add(StepForward.CreateComponent(this.actingCombatant.gameObject, new UnityEngine.Vector3(-0.5f, 0.0f, 0.0f)));
            actionsToQueue.Add(Actions.Attacks.AttackMelee.CreateComponent(this.actingCombatant.gameObject, abilitySelection.targets));
            actionsToQueue.Add(StepForward.CreateComponent(this.actingCombatant.gameObject, new UnityEngine.Vector3(0.0f, 0.0f, 0.0f)));
            actionsToQueue.Add(this.actingCombatant.gameObject.AddComponent<TurnFinished>());

            foreach (ActorAction combatAction in actionsToQueue) {

                // Each action has a reference to its source ability.
                combatAction.SetAbilitySelection(abilitySelection);
            }

            this.actingCombatant.Actions.SetActions(actionsToQueue.ToArray());
        }

        public override List<AbilityResult> Process(List<Combatant> targets) {

            List<AbilityResult> results = new List<AbilityResult>();

            // It's a physical attack, so let's do some physical damage!
            if(this.model.PhysicalDamageModifier != 0) {
                foreach (Combatant target in targets) {
                    results.Add(DamageCalculator.CalculatePhysicalDamage(this.actingCombatant, target, this.model.PhysicalDamageModifier));
                }
            }

            return results;
        }
    }
}
