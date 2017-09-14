using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Movement {

    public class RotateToFace : CombatAction
    {
        private float timer;

        private Quaternion targetRotation;
        public Quaternion TargetRotation {
            get { return targetRotation; }
            set { targetRotation = value; }
        }


        /// <summary>
        /// The animator attached to this combatant.
        /// </summary>
        private Animator animator;

        public override void Awake() {
            base.Awake();
            this.animator = this.gameObject.GetComponentInChildren<Animator>();
            this.targetRotation = this.transform.rotation;
            this.timer = 3.0f;
        }

        private void Start() {
            this.animator.SetBool("moving", true);
        }

        void FixedUpdate() {

            this.transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * MovementConstants.RotationSpeed);

            // Check if the combatant has arrived at their location. if they have, remove the script.
            if (this.timer > 0.0f) {
                this.timer -= 0.0f;
            }
            else {
                this.transform.rotation = targetRotation;
                this.complete = true;
            }
        }

        private void OnDestroy() {
            this.animator.SetBool("moving", false);
        }
    }
}
