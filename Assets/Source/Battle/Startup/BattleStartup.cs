using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.StateProcesses;
using Assets.Source.DataAccessLayer;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Startup {

    /// <summary>
    /// The BattleStartup script must exist in a battle scene when it is loaded. This handles all of the logic for generating
    /// the battle.
    /// </summary>
    public class BattleStartup : MonoBehaviour  {

        private void Awake() {

            // Get the player party from the data repository.
            Party playerParty = DataRepository.Instance().Parties.GetByName("main");

            List<GameObject> players = new List<GameObject>();
            List<GameObject> enemies = new List<GameObject>();

            foreach(string partyMember in playerParty.Members) {

                // We want to spawn a combatant for each player in the party.
                GameObject playerCombatant = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/Characters/{0}", "PlayerCharacter 1")));
                PlayerCombatant player = playerCombatant.GetComponent<PlayerCombatant>();
                player.Character = DataRepository.Instance().Characters.GetByName(partyMember);
                players.Add(playerCombatant);
            }

            // Get the enemy party
            Party enemyParty = BattleTransitionContainer.EnemyParty;

            // If the enemy party is null, grab the test party.
            if (enemyParty == null)
                enemyParty = DataRepository.Instance().Parties.GetByName("test1");

            foreach(string partyMember in enemyParty.Members) {

                // We want to spawn a combatant for each player in the party.
                GameObject enemyCombatant = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/Characters/{0}", "Enemy")));
                EnemyCombatant enemy = enemyCombatant.GetComponent<EnemyCombatant>();
                enemy.Enemy = DataRepository.Instance().Enemies.GetByName(partyMember);
                enemies.Add(enemyCombatant);
            }

            UnitPlacement unitPlacement = this.GetComponentInChildren<UnitPlacement>();

            unitPlacement.PlacePlayers(players);
            unitPlacement.PlaceEnemies(enemies);

            GameObject.Find("BattleManager").GetComponent<BattleManager>().StoreCombatants(players, enemies);
        }

        private void Start() {
            BattleEventManager.Instance().BattleStart();
        } 
    }
}
