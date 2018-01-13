using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.StateProcesses {
    public class TurnController {

        private BattleManager battleManager;
        private int index;
        private List<AbilitySelection> abilitySelections;

        public TurnController(BattleManager manager, List<AbilitySelection> abilitySelections) {
            this.battleManager = manager;
            this.abilitySelections = abilitySelections;
            this.index = 0;
            BattleEventManager.Instance().onAbilityCompleted += BeginNextAction;
        }

        public void BeginNextAction() {
            
            // End the turn if we have processed all abilities
            if(index == abilitySelections.Count) {
                this.index = 0;
                this.abilitySelections = null;
                BattleEventManager.Instance().onAbilityCompleted -= BeginNextAction;
                BattleEventManager.Instance().EndTurn();
            } 
            // Process the ability
            else {
                abilitySelections[index].results = abilitySelections[index].ability.Process(abilitySelections[index].targets);
                abilitySelections[index].ability.AttachScripts(abilitySelections[index]);
                index++;
            }
        }

        // There may be enemies to clean up, or actions to remove in between each attack, so we should manage that here.
        private void Cleanup() {

            // Get the dead enemies
            List<EnemyCombatant> deadCombatants = battleManager.Enemies.Where(enemy => enemy.GetStats().Health.Current <= 0).ToList();

            foreach(EnemyCombatant enemy in deadCombatants) {
                GameObject.Destroy(enemy.gameObject);
                battleManager.Enemies.Remove(enemy);
            }
        }

        private bool IsBattleFinished() {

            if(this.battleManager.Enemies.Count == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        public void BeginNextAction(Combatant combatant, Ability ability) {

            // Cleanup any resources between the last action and this one.
            this.Cleanup();

            // Check if the battle win condition was met in the last action.
            if (!IsBattleFinished()) {
                this.BeginNextAction();
            }
            else {
                BattleEventManager.Instance().onAbilityCompleted -= BeginNextAction;
                BattleEventManager.Instance().BattleEnd();
            }
        }
    }
}
