using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Movement {
    public class IdleLookAt : CombatAction {

        private void Update() {

            Combatant target = this.gameObject.GetComponent<Combatant>().Target;

            if (target != null) {
                // We interpolate the rotation so that it's gradual.
                Vector3 relativePos = target.gameObject.transform.position - this.transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                this.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * MovementConstants.RotationSpeed);
            }
        }
    }
}
