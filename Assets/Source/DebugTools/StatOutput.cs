using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.StateProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.DebugTools {
    public class StatOutput : MonoBehaviour {

        private BattleManager battleManager;

        private void Awake() {
            this.battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        }

        private void Update() {

            if (Input.GetKeyDown(KeyCode.S)) {
                List<PlayerCombatant> combatants = battleManager.Players;
                List<EnemyCombatant> enemyCombatants = battleManager.Enemies;

                Debug.Log("Players");
                foreach(PlayerCombatant combatant in combatants) {
                    Debug.Log(string.Format("[Name:{0}] [HP:{1}] [MTM:{2}]", combatant.Character.Name, combatant.GetStats().Health.Current, combatant.Momentum));
                }

                Debug.Log("Enemies");
                foreach(EnemyCombatant combatant in enemyCombatants) {
                    Debug.Log(string.Format("[Name:{0}] [HP:{1}] [MTM:{2}]", combatant.Enemy.Name, combatant.GetStats().Health.Current, combatant.Momentum));
                }
            }
        }
    }
}
