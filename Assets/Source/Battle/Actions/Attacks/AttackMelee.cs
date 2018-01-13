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
    public class AttackMelee : ActorAction, ITargetedAction {

        private List<Combatant> targets;
        private Animator animator;
        private SpellAnimation spellAnimation;

        /// <summary>
        /// A timer that controls when this action is considered finished. This begins incrementing
        /// </summary>
        private float finishActionTimer;

        public static AttackMelee CreateComponent(GameObject objectToAttachTo, List<Combatant> targets) {
            AttackMelee action = objectToAttachTo.AddComponent<AttackMelee>();
            action.targets = targets;

            return action;
        }

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

            foreach (Combatant target in targets) {
                GameObject spell = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/Spells/{0}", this.abilitySelection.ability.Model.Metadata.SpellAnimation)), target.transform.position, Quaternion.identity);
                this.spellAnimation = spell.GetComponent<SpellAnimation>();
                this.spellAnimation.abilitySelection = this.abilitySelection;
                this.spellAnimation.source = this.combatant;
                this.spellAnimation.target = target;
            }
        }

        public void SetTarget(Combatant combatant) {
            //this.target = combatant;
        }

        public void Update() {
            if(this.spellAnimation == null) {
                this.complete = true;
            }
        }
    }
}
