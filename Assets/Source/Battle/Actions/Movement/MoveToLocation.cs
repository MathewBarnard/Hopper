using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Movement {
    public class MoveToLocation : CombatAction {

        private Vector3 targetLocation;
        public Vector3 TargetLocation {
            get { return targetLocation; }
            set { targetLocation = value; }
        }

        /// <summary>
        /// The animator attached to this combatant.
        /// </summary>
        private Animator animator;

        public override void Awake() {
            base.Awake();
            this.animator = this.gameObject.GetComponentInChildren<Animator>();
        }

        private void Start() {
            this.animator.SetBool("moving", true);
        }

        void Update() {

            this.transform.position += this.transform.forward * (Time.deltaTime * MovementConstants.BaseMovementSpeed);

            //// Handle rotation towards the combatant
            Vector3 relativePos = targetLocation - this.transform.position;
            relativePos.y = this.transform.position.y;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            rotation.x = 0;
            rotation.z = 0;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * MovementConstants.RotationSpeed);

            // Check if the combatant has arrived at their location. if they have, remove the script.
            if (Vector3.Distance(this.transform.position, targetLocation) < 1.0f) {
                this.complete = true;
            }
        }

        private void OnDestroy() {
            this.animator.SetBool("moving", false);
        }
    }
}
