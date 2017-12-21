using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Entities;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Attacks {
    public class Ember : ActorAction, ITargetedAction {

        private Combatant target;
        private Animator animator;
        private SpellAnimation spellAnimation;

        /// <summary>
        /// A timer that controls when this action is considered finished. This begins incrementing
        /// </summary>
        private float finishActionTimer;

        public override void Awake() {

            base.Awake();

            this.animator = this.gameObject.GetComponentInChildren<Animator>();
        }

        void Start() {

            //this.animator.SetTrigger("attack");
            SpawnAttackSpell();
        }

        /// <summary>
        /// Spawn an attack spell into the world.
        /// </summary>
        public void SpawnAttackSpell() {

            GameObject spell = Instantiate((GameObject)Resources.Load("Prefabs/Battle/Spells/sword_attack_0"), target.transform.position, Quaternion.identity);
            this.spellAnimation = spell.GetComponent<AttackMeleeAnimation>();
            this.spellAnimation.sourceAbility = this.ability;
            this.spellAnimation.source = this.combatant;
            this.spellAnimation.target = this.target;
        }

        public void SetTarget(Combatant combatant) {
            this.target = combatant;
        }

        public void Update() {
            if (this.spellAnimation == null) {
                this.complete = true;
            }
        }
    }
}
