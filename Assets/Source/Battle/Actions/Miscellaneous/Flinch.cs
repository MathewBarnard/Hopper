using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Miscellaneous {
    public class Flinch : CombatAction {

        private const float baseFlinchTime = 0.5f;

        private Animator animator;

        private float timer;

        public override void Awake() {

            base.Awake();

            this.animator = this.gameObject.GetComponentInChildren<Animator>();

            timer = 0.0f;
        }

        private void Start() {
            this.animator.SetTrigger("damaged");
        } 

        private void Update() {

            timer += Time.deltaTime;

            if(timer > baseFlinchTime) {
                this.complete = true;
            }
        }
    }
}
