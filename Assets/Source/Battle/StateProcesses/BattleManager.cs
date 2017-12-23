using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.StateProcesses {
    public class BattleManager : MonoBehaviour {

        /// <summary>
        /// TurnController used to marionette the player and enemies actions
        /// </summary>
        private TurnController turnController;

        /// <summary>
        /// The characters turn queue
        /// </summary>
        private Queue<Combatant> turnQueue;

        /// <summary>
        /// All player characters in the battle.
        /// </summary>
        private List<PlayerCombatant> players;
        public List<PlayerCombatant> Players {
            get { return players;}
        }

        /// <summary>
        /// All enemy characters in the battle.
        /// </summary>
        private List<EnemyCombatant> enemies;
        public List<EnemyCombatant> Enemies {
            get { return enemies; }
        }

        /// <summary>
        /// The abilities that have been selected this turn
        /// </summary>
        private List<AbilitySelection> abilitySelection;

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
            BattleEventManager.Instance().onBeginPlayTurn += ProcessTurn;
            BattleEventManager.Instance().onEndTurn += EndTurn;
            BattleEventManager.Instance().onBattleEnd += BattleEnd;
            this.abilitySelection = new List<AbilitySelection>();
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
        }

        private void NextCombatant() {
            if (this.turnQueue.Count > 0) {
                Combatant previous = this.actingCombatant;
                this.actingCombatant = this.turnQueue.Dequeue();
                BattleEventManager.Instance().BeginActionSelection(this.actingCombatant, previous);
            }
            else {
                BattleEventManager.Instance().BeginPlayTurn();
            }
        }

        private void NextTurn() {
            NextCombatant();
        }

        private void ActionSelected(Combatant combatant, Ability ability) {
            // The ability knows which combatant is using it.
            ability.ActingCombatant = combatant;

            this.abilitySelection.Add(new AbilitySelection { combatant = combatant, ability = ability} );
        }

        private void TargetSelected(List<Combatant> targets) {

            abilitySelection.Where(abl => abl.combatant == actingCombatant).First().targets = targets;
            NextCombatant();
        }

        public void ProcessTurn() {
            this.turnController = new TurnController(this,this.abilitySelection);
        }

        private void EndTurn() {

            this.abilitySelection.Clear();
            this.actingCombatant = null;
            this.turnController = null;
            SetupQueue();
            NextTurn();
        }

        public void BattleEnd() {
            EngineEventManager.Instance().GameStateExit();
        }

        public void OnDestroy() {
            BattleEventManager.Instance().onBattleStart -= NextTurn;
            BattleEventManager.Instance().onActionSelected -= ActionSelected;
            BattleEventManager.Instance().onTargetSelected -= TargetSelected;
            BattleEventManager.Instance().onBeginPlayTurn -= ProcessTurn;
            BattleEventManager.Instance().onEndTurn -= EndTurn;
            BattleEventManager.Instance().onBattleEnd -= BattleEnd;
        }
    }
}
