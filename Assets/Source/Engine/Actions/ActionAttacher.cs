//using Assets.Source.Battle.Actions.Miscellaneous;
//using Assets.Source.Battle.Combatants;
//using Assets.Source.Battle.Events;
//using Assets.Source.Battle.Spells.Abilities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Assets.Source.Engine.Actions {
//    public class ActionAttacher {

//        public static void AttachScriptsForAbility(Combatant combatant, Ability ability) {

//            Type[] actions = ability.GetActions();

//            List<ActorAction> actionsToQueue = new List<ActorAction>();

//            foreach(Type action in actions) {
//                // Add the script to the combatant
//                ActorAction combatAction = (ActorAction)combatant.gameObject.AddComponent(action);

//                // Unsure what this was doing before.
//                combatAction.SetAbility(ability);

//                // A control switch to ensure that we instantiate any requirements of the script
//                if(combatAction is ITargetedAction) {
//                    // Set the target for the combat action
//                    ITargetedAction targetedAction = combatAction as ITargetedAction;
//                    //targetedAction.SetTarget(combatant.Target);
//                    //BattleEventManager.Instance().CombatantTargeted(combatant.Target, combatant);
//                }

//                // Add the action to the queue.
//                actionsToQueue.Add(combatAction);
//            }

//            combatant.Actions.SetActions(actionsToQueue.ToArray());
//        }

//        public static void AttachScriptsForAbility(Combatant combatant, Ability ability, Combatant target) {

//            Type[] actions = ability.GetActions();

//            List<ActorAction> actionsToQueue = new List<ActorAction>();

//            foreach (Type action in actions) {
//                // Add the script to the combatant
//                ActorAction combatAction = (ActorAction)combatant.gameObject.AddComponent(action);

//                // Unsure what this was doing before.
//                combatAction.SetAbility(ability);

//                // A control switch to ensure that we instantiate any requirements of the script
//                if (combatAction is ITargetedAction) {
//                    // Set the target for the combat action
//                    ITargetedAction targetedAction = combatAction as ITargetedAction;
//                    targetedAction.SetTarget(target);
//                }

//                // Add the action to the queue.
//                actionsToQueue.Add(combatAction);
//            }

//            combatant.Actions.SetActions(actionsToQueue.ToArray());
//        }
//    }
//}
