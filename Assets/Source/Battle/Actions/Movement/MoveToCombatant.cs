using Assets.Source.Battle.Combatants;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Movement {
    public class MoveToCombatant : ActorAction, ITargetedAction {

        /// <summary>
        /// The animator attached to this combatant.
        /// </summary>
        private Animator animator;

        // The target combatant to move towards
        private Combatant target;
        public Combatant Target {
            get { return target; }
            set { target = value; }
        }

        public override void Awake() {
            base.Awake();
            this.animator = this.gameObject.GetComponentInChildren<Animator>();
        }

        void Start() {
            //this.animator.SetBool("moving", true);
        }

        // Update is called once per frame
        void Update() {

            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, 1.0f * Time.deltaTime);

            //// Handle rotation towards the combatant
            //Vector3 relativePos = target.gameObject.transform.position - this.transform.position;
            //relativePos.y = this.transform.position.y;
            //Quaternion rotation = Quaternion.LookRotation(relativePos);
            //rotation.x = 0;
            //rotation.z = 0;
            //this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * MovementConstants.RotationSpeed);
        }

        void OnTriggerStay2D(Collider2D col) {
            if (target != null) {
                if (col.gameObject == target.gameObject) {
                    complete = true;
                }
            }
        }

        private void OnDestroy() {
            //this.animator.SetBool("moving", false);
        }

        public void SetTarget(Combatant combatant) {
            target = combatant;
        }
    }
}
