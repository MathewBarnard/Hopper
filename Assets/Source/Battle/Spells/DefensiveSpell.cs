using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells {
    public class DefensiveSpell : SpellHitbox {

        private void OnTriggerEnter(Collider other) {

            Combatant hit = other.GetComponent<Combatant>();

            if (source is PlayerCombatant) {

                if (hit is PlayerCombatant) {
                    Debug.Log(hit.name);
                    Destroy(this.gameObject);
                }
            }
            else {

                if (hit is EnemyCombatant) {
                    Debug.Log(hit.name);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
