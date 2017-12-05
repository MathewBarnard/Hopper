using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Movement {
    public class StepBackward: CombatAction {

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
            //this.animator.SetBool("moving", true);
            this.targetLocation = this.gameObject.transform.position + new Vector3(0.5f, 0.0f, 0.0f);
        }

        void FixedUpdate() {

            this.transform.position = Vector3.MoveTowards(this.transform.position, targetLocation, 3.0f * Time.deltaTime);

            // Check if the combatant has arrived at their location. if they have, remove the script.
            if (Vector3.Distance(this.transform.position, targetLocation) < 0.01f) {
                this.transform.position = new Vector3(this.targetLocation.x, this.transform.position.y, this.targetLocation.z);
                this.complete = true;
            }
        }

        private void OnDestroy() {
            //this.animator.SetBool("moving", false);
        }
    }
}
