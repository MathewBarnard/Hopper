using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions {
    public class CombatAction : MonoBehaviour {
        
        /// <summary>
        /// Executing = the action is being performed.
        /// Wind down = the action has finished, and we are in the grace period before the action is resolved.
        /// </summary>
        public enum ActionState { EXECUTING, WIND_DOWN }

        /// <summary>
        /// The current state of the action. 
        /// </summary>
        protected ActionState actionState;
        public ActionState State {
            get { return actionState; }
        }

        /// <summary>
        /// The combatant performing the action.
        /// </summary>
        protected Combatant combatant;

        /// <summary>
        /// The ability that triggered this action.
        /// </summary>
        protected Ability ability;

        /// <summary>
        /// A period of time before we consider this action "complete." The grace period begins counting down once
        /// the primary function of the action has been completed. This allows time for animations to complete.
        /// </summary>
        protected float gracePeriod;

        protected bool complete;
        public bool Complete {
            get { return complete; }
        }

        public void SetAbility(Ability ability) {
            this.ability = ability;
        }

        public virtual void Awake() {
            combatant = this.gameObject.GetComponent<Combatant>();
            enabled = false;
            actionState = ActionState.EXECUTING;
        }
    }
}
