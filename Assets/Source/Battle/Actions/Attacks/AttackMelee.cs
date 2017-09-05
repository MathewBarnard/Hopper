using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Attacks {
    public class AttackMelee : CombatAction, ITargetedAction {

        /// <summary>
        /// An attack has a grace period of two seconds after it has been used.
        /// </summary>
        private const float GracePeriod = 2.0f;

        private Combatant target;

        private Animator animator;

        /// <summary>
        /// A timer that controls when this action is considered finished. This begins incrementing
        /// </summary>
        private float finishActionTimer;

        public override void Awake() {

            base.Awake();

            this.animator = this.gameObject.GetComponentInChildren<Animator>();

            this.gracePeriod = GracePeriod;
        }

        void Update() {

            // Reduce the grace period by the current frame time.
            if(this.actionState == ActionState.WIND_DOWN) {
                this.gracePeriod -= Time.deltaTime;

                // The action has completely resolved.
                if(this.gracePeriod <= 0) {
                    this.complete = true;
                }
            }
        }

        void Start() {

            this.animator.SetTrigger("attack");

            this.target = this.combatant.gameObject.GetComponent<Combatant>().Target;
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

            this.actionState = ActionState.WIND_DOWN;
        }

        public void SetTarget(Combatant combatant) {
            this.target = combatant;
        }
    }
}
