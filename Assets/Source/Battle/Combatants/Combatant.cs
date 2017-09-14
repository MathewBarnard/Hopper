using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Miscellaneous;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants {
    public class Combatant : MonoBehaviour {

        /// <summary>
        /// How much 'momentum' a character has to empower their attacks.
        /// </summary>
        private int momentum;
        public int Momentum {
            get { return momentum; }
            set { momentum = value; }
        }

        /// <summary>
        /// The spellbook of the character. Used primarily to store ability cooldowns.
        /// </summary>
        protected Spellbook spellbook;
        public Spellbook Spellbook {
            get { return spellbook; }
        }

        // The heros action queue
        protected ActionQueue actions;
        public ActionQueue Actions {
            get { return actions; }
        }

        public virtual void Awake() {

            // Disable the combatant, and listen for an event when the battle starts.
            enabled = false;

            BattleEventManager.Instance().onBattleStart += this.Enable;
            BattleEventManager.Instance().onCombatantDamaged += this.Flinch;
        }

        public virtual void Start() {
            this.actions = this.gameObject.GetComponent<ActionQueue>();
        }

        public void Enable() {
            this.enabled = true;
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

        public virtual Models.Statistics GetStats() {
            return null;
        }
    }
}
