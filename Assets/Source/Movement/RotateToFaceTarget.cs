using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Movement;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Movement {
    public class RotateToFaceTarget : MonoBehaviour {

        private const float rotationSpeed = 2.0f;

        /// <summary>
        /// A reference to the action queue for the combatant so that we can check if they are idle.
        /// </summary>
        private ActionQueue queue;

        /// <summary>
        /// A reference to the combatant who this script is attached to.
        /// </summary>
        private Combatant combatant;

        /// <summary>
        /// The transform of the target for the combatant to look at.
        /// </summary>
        private Combatant target;

        private void Start() {

            // Get target of this combatant.
            this.combatant = this.gameObject.GetComponent<Combatant>();
            this.queue = this.gameObject.GetComponent<ActionQueue>();
        }

        public void SetNewTarget(Combatant targetedCombatant, Combatant targetedBy) {

            // Check that this event is for this combatant
            if(targetedBy == this.combatant) {
                this.target = targetedCombatant;
            }
        }

        private void Update() {

            if (this.queue.ActionCount == 0)
            {
                if (target != null) {
                    // We interpolate the rotation so that it's gradual.
                    Vector3 relativePos = target.gameObject.transform.position - this.transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos);
                    this.transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * MovementConstants.RotationSpeed);
                }
            }
        }
    }
}
