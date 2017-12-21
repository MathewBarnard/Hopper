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

        private List<PlayerCombatant> players;
        private List<EnemyCombatant> enemies;
        private Ability ability;

        void Awake() {
            BattleEventManager.Instance().onActionSelected += Enable;
            BattleEventManager.Instance().onTargetingCancelled += Disable;
        }

        private void Start() {
            GameObject battleManager = GameObject.Find("BattleManager");
            this.players = battleManager.GetComponent<BattleManager>().Players;
            this.enemies = battleManager.GetComponent<BattleManager>().Enemies;
            this.enabled = false;
        }

        private void Update() {

            if (UnityEngine.Input.GetMouseButtonDown(0)) {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


                if (hit.collider != null) {

                    List<Combatant> targets = new List<Combatant>();

                    if (this.ability.TargetingType == TargetingType.OFFENSIVE_SINGLE || this.ability.TargetingType == TargetingType.OFFENSIVE_ALL) {

                        foreach (EnemyCombatant enemy in enemies) {

                            if (hit.collider.gameObject == enemy.gameObject) {

                                if(this.ability.TargetingType == TargetingType.OFFENSIVE_SINGLE)
                                    targets.Add(enemy);
                                else
                                    targets.AddRange(enemies.Cast<Combatant>().ToList());
                                BattleEventManager.Instance().TargetSelected(targets);
                                Disable();
                                return;
                            }
                        }
                    }
                    else if(this.ability.TargetingType == TargetingType.DEFENSIVE_SINGLE || this.ability.TargetingType == TargetingType.DEFENSIVE_ALL) {
                        foreach(PlayerCombatant player in players) {

                            if (hit.collider.gameObject == player.gameObject) {
                                
                                if(this.ability.TargetingType == TargetingType.DEFENSIVE_SINGLE)
                                    targets.Add(player);
                                else
                                    targets.AddRange(players.Cast<Combatant>().ToList());
                                BattleEventManager.Instance().TargetSelected(targets);
                                Disable();
                                return;
                            }
                        }
                    }
                }
            }
        } 

        public void Enable(Combatant combatant, Ability ability) {
            this.ability = ability;
            this.enabled = true;
        }

        public void Disable() {
            this.ability = null;
            this.enabled = false;
        }

        public void OnDestroy() {
            BattleEventManager.Instance().onActionSelected -= Enable;
            BattleEventManager.Instance().onTargetingCancelled -= Disable;
        }
    }
}
