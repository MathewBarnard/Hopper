using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Attacks {
    public class AttackMelee : CombatAction, ITargetedAction {

        private Combatant target;

        private Animator animator;

        /// <summary>
        /// A timer that controls when this action is considered finished. This begins incrementing
        /// </summary>
        private float finishActionTimer;

        public override void Awake() {

            base.Awake();

            this.animator = this.gameObject.GetComponentInChildren<Animator>();
        }

        void Start() {

            this.animator.SetTrigger("attack");

            //this.target = this.combatant.gameObject.GetComponent<Combatant>().Target;
        }

        /// <summary>
        /// Spawn an attack spell into the world.
        /// </summary>
        public void SpawnAttackSpell() {

            GameObject spell = Instantiate((GameObject)Resources.Load("Prefabs/Battle/Spells/spell_attack"), target.transform.position, Quaternion.identity);
            SpellHitbox hitboxScript = spell.gameObject.GetComponent<SpellHitbox>();

            if(hitboxScript != null) {
                hitboxScript.source = this.combatant;
            }

            complete = true;
        }

        public void SetTarget(Combatant combatant) {
            this.target = combatant;
        }
    }
}
