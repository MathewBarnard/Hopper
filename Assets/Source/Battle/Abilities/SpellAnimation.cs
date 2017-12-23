using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.StateProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells {
    public abstract class SpellAnimation : MonoBehaviour {

        private Animator animator;
        public Combatant target;
        public Combatant source;
        public AbilitySelection abilitySelection;

        private void Start() {
            this.animator = this.gameObject.GetComponent<Animator>();
        }

        private void Update() {

            // Check that the animation has finished
            if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("finished")) {
                Destroy(this.gameObject);
            }
        }

        //public abstract void SpawnNumber();

        protected void SpawnNumber(int result) {
            //UI.AbilityTextPopup.Create(result.ToString());
        }

        protected void SpawnNumber(int result, Vector2 origin) {
            UI.AbilityTextPopup.Create(result.ToString(), this.target.transform.position);
        }
    }
}
