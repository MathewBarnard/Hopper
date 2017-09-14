using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants.Enemies.Conditions {

    public class EnemyInRange : EnemyBehaviour {

        private Combatant combatant;
        public Combatant combatantInRange;

        private void Awake() {

            this.combatant = this.transform.parent.gameObject.GetComponent<Combatant>();
        } 

        private void OnTriggerEnter(Collider otherObject) {

            // We're only concerned with triggers.
            if (!otherObject.isTrigger)
                return;

            if (otherObject.tag == "Combatant") {

                if (this.combatant is PlayerCombatant) {

                    EnemyCombatant enemy = otherObject.GetComponent<EnemyCombatant>();

                    if (enemy != null) {
                        this.combatantInRange = enemy;
                        trigger.Invoke();
                    }
                }
                else if (this.combatant is EnemyCombatant) {

                    PlayerCombatant player = otherObject.GetComponent<PlayerCombatant>();

                    if(player != null) {
                        this.combatantInRange = player;
                        trigger.Invoke();
                    }
                }
            }
        }

        protected override void Trigger() {
            Debug.Log("Do something!");
        }
    }
}
