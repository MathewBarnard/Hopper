using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Abilities {
    public class Casting : CombatAction {

        private Combatant target;

        private Animator animator;

        private float castTime;

        private float castingFor;

        public override void Awake() {

            base.Awake();

            this.animator = this.gameObject.GetComponentInChildren<Animator>();

            // Get the casting time from the associated ability
            this.castTime = 5.0f;
            this.castingFor = 0.0f;
        }

        void Start() {

            this.animator.SetTrigger("casting");

            //this.target = this.combatant.gameObject.GetComponent<Combatant>().Target;
        }

        private void Update() {

            castingFor += Time.deltaTime;

            if(castingFor >= castTime) {

                this.complete = true;
            }
        } 
    }
}
