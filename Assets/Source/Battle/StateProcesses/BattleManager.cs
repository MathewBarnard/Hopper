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
    public class BattleManager : MonoBehaviour {

        /// <summary>
        /// The characters turn queue
        /// </summary>
        private Queue<Combatant> turnQueue;

        /// <summary>
        /// All player characters in the battle.
        /// </summary>
        private List<PlayerCombatant> players;

        /// <summary>
        /// All enemy characters in the battle.
        /// </summary>
        private List<EnemyCombatant> enemies;
        public List<EnemyCombatant> Enemies {
            get { return enemies; }
        }

        /// <summary>
        /// The currently acting combatant
        /// </summary>
        private Combatant actingCombatant;

        /// <summary>
        /// The ability that the player is going to cast.
        /// </summary>
        private Ability ability;

        /// <summary>
        /// Subscribe to events that the BattleManager is concerned with.
        /// </summary>
        private void Awake() {

            BattleEventManager.Instance().onBattleStart += NextTurn;
            BattleEventManager.Instance().onActionSelected += ActionSelected;
            BattleEventManager.Instance().onTargetSelected += TargetSelected;
            BattleEventManager.Instance().onEndTurn += EndTurn;
        }

        /// <summary>
        /// Store all of the combatants during startup.
        /// </summary>
        /// <param name="players">Player combatants.</param>
        /// <param name="enemies">Enemy combatants.</param>
        public void StoreCombatants(List<PlayerCombatant> players, List<EnemyCombatant> enemies) {

            if(this.players == null) {
                this.players = new List<PlayerCombatant>();
            }

            if(this.enemies == null) {
                this.enemies = new List<EnemyCombatant>();
            }

            this.players = players;
            this.enemies = enemies;
        }

        /// <summary>
        /// Store all of the combatants during startup.
        /// </summary>
        /// <param name="players">Player combatants.</param>
        /// <param name="enemies">Enemy combatants.</param>
        public void StoreCombatants(List<GameObject> players, List<GameObject> enemies) {

            if (this.players == null) {
                this.players = new List<PlayerCombatant>();
            }

            if (this.enemies == null) {
                this.enemies = new List<EnemyCombatant>();
            }

            foreach (GameObject player in players) {
                this.players.Add(player.GetComponent<PlayerCombatant>());
            }

            foreach(GameObject enemy in enemies) {
                this.enemies.Add(enemy.GetComponent<EnemyCombatant>());
            }

            // Setup the action queue once we have stored our combatants.
            this.SetupQueue();
        }

        private void SetupQueue() {

            this.turnQueue = new Queue<Combatant>();

            foreach(Combatant combatant in players) {

                this.turnQueue.Enqueue(combatant);
            }

            foreach(Combatant combatant in enemies) {

                this.turnQueue.Enqueue(combatant);
            }
        }

        private void NextTurn() {

            this.actingCombatant = this.turnQueue.Dequeue();
            BattleEventManager.Instance().BeginTurn(this.actingCombatant);
        }

        private void ActionSelected(Combatant combatant, Ability ability) {
            this.ability = ability;
        }

        private void TargetSelected(List<Combatant> targets) {

            if(ability.TargetingType == TargetingType.Single) {
                ActionAttacher.AttachScriptsForAbility(this.actingCombatant, ability, targets[0]);
            }
        }

        private void EndTurn() {

            this.turnQueue.Enqueue(this.actingCombatant);
            NextTurn();
        }
    }
}
