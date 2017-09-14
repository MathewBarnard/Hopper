using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.StateProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {
    public class TargetController : MonoBehaviour {

        private List<EnemyCombatant> enemies;
        private EnemyCombatant target;
        private int index;

        void Awake() {
            BattleEventManager.Instance().onActionSelected += Enable;
            BattleEventManager.Instance().onTargetingCancelled += Disable;
        }

        private void Start() {
            GameObject battleManager = GameObject.Find("BattleManager");
            this.enemies = battleManager.GetComponent<BattleManager>().Enemies;
            this.enabled = false;
        }

        private void Update() {

            if (Input.GetButtonDown("Horizontal")) {

                Combatant oldTarget = null;
                Combatant newTarget = null;

                if (Input.GetAxisRaw("Horizontal") == 1) {

                    oldTarget = enemies[index];

                    if (index == enemies.Count - 1)
                        index = 0;
                    else
                        index += 1;

                    newTarget = enemies[index];

                    BattleEventManager.Instance().TargetChanged(oldTarget, newTarget);
                }
                else if (Input.GetAxisRaw("Horizontal") == -1) {

                    oldTarget = enemies[index];

                    if (index == 0)
                        index = enemies.Count - 1;
                    else
                        index -= 1;

                    newTarget = enemies[index];

                    BattleEventManager.Instance().TargetChanged(oldTarget, newTarget);
                }
            }

            if(Input.GetButtonDown("Submit")) {
                BattleEventManager.Instance().onTargetSelected();
            }
        } 

        public void Enable(Combatant combatant, Ability ability) {

            this.enabled = true;
            this.target = this.enemies[0];
            this.index = 0;
            BattleEventManager.Instance().TargetChanged(null, enemies[index]);
        }

        public void Disable() {

            this.enabled = false;
        }
    }
}
