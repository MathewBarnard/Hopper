using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Miscellaneous;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants {
    public class Combatant : MonoBehaviour {

        /// <summary>
        /// The current target that the combatant has set
        /// </summary>
        protected Combatant target;
        public Combatant Target {
            get { return target; }
            set { target = value; }
        }

        /// <summary>
        /// The current ability that the character is configured to use.
        /// </summary>
        protected Ability selectedAbility;
        public Ability SelectedAbility {
            get { return selectedAbility; }
        }

        // The heros action queue
        protected ActionQueue actions;
        public ActionQueue Actions {
            get { return actions; }
        }

        /// <summary>
        /// The atb gauge attached to the combatant.
        /// </summary>
        protected AtbGauge atbGauge;
        public AtbGauge AtbGauge {
            get { return atbGauge; }
        }

        public virtual void Awake() {

            // Disable the combatant, and listen for an event when the battle starts.
            enabled = false;

            BattleEventManager.Instance().onBattleStart += this.Enable;
            BattleEventManager.Instance().onCombatantDamaged += this.Flinch;
        }

        public void Start() {
            this.actions = this.gameObject.GetComponent<ActionQueue>();
            this.atbGauge = this.gameObject.GetComponent<AtbGauge>();
        }

        public void Enable() {
            this.enabled = true;
            BattleEventManager.Instance().onBattleStart -= this.Enable;
        }

        /// <summary>
        /// This function is called whenever a combatant takes damage. We perform a check to see if this combatant is the target. If so, we push a flinch action to the front of
        /// the queue.
        /// </summary>
        public void Flinch(Combatant combatant) {

            if(combatant == this) {

                Flinch flinchAction = this.gameObject.AddComponent<Flinch>();
                this.Actions.AddToFront(flinchAction);
            }
        }
    }
}
