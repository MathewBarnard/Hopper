using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells {
    public class OffensiveSpell : SpellHitbox {

        public int hitsPerCombatant;
        private Dictionary<Combatant, int> hitCombatants;

        private void Awake() {
            hitCombatants = new Dictionary<Combatant, int>();
        } 

        private void OnTriggerEnter(Collider other) {

            Combatant hit = other.GetComponent<Combatant>();

            if (source is PlayerCombatant) {

                if (hit is EnemyCombatant) {

                    if(!hitCombatants.ContainsKey(hit)) {

                        this.hitCombatants.Add(hit, 1);
                        BattleEventManager.Instance().CombatantHit(hit);
                        this.ProcessEffect(hit);
                    }
                    else {
                        if (this.hitCombatants[hit] < hitsPerCombatant) {
                            this.hitCombatants[hit] += 1;
                            BattleEventManager.Instance().CombatantHit(hit);
                            this.ProcessEffect(hit);
                        }
                    }

                    if (this.hitCombatants[hit] >= hitsPerCombatant) {
                        Destroy(this.gameObject);
                    }
                }
            }
            else {

                if (hit is PlayerCombatant) {                  
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
