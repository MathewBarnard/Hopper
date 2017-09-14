using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras.Development {
    public class LookAt : MonoBehaviour {

        private Combatant target;

        private void Update() {

            Quaternion targetRotation = Quaternion.LookRotation(target.gameObject.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1.0f * Time.deltaTime);
        }

        public void LookAtCombatant(Combatant combatant) {
            target = combatant;
            enabled = true;
        }
    }
}
