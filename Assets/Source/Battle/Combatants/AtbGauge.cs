using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants {

    /// <summary>
    /// A controller for a characters Atb Gauge.
    /// </summary>
    public class AtbGauge: MonoBehaviour {

        public bool actionLocked;

        public const float AtbMax = 100.0f;

        /// <summary>
        /// The combatant that this AtbGauge is associated with.
        /// </summary>
        private Combatant combatant;

        /// <summary>
        /// The ATB gauge that reflects when this character is able to act.
        /// </summary>
        protected float atb;
        public float Atb {
            get { return atb; }
        }

        /// <summary>
        /// The rate at which this characters atb increases per second. This is affected by their speed, buffs, momentum etc. 
        /// </summary>
        protected float atbPerSecond;

        private void Awake() {
            this.combatant = this.gameObject.GetComponent<Combatant>();

            //BattleEventManager.Instance().onBattleResume += Resume;
        }

        private void Start() {
            if (this.combatant is EnemyCombatant)
                atbPerSecond = Convert.ToSingle((this.combatant as EnemyCombatant).Enemy.Stats.Speed.Current);
            else
                atbPerSecond = Convert.ToSingle((this.combatant as PlayerCombatant).Character.Stats.Speed.Current);

            this.actionLocked = false;
        }

        void Update() {

            if(this.combatant.Actions.ActionCount == 0 && atb < AtbMax)
                atb += atbPerSecond * Time.deltaTime;

            // The combatant has enough ATB to choose an action, and is currently not acting.
            if (atb >= AtbMax && this.combatant.Actions.ActionCount == 0 && this.actionLocked == false) {
                BattleEventManager.Instance().CombatantAtbFull(this.combatant);
                this.actionLocked = true;
                this.enabled = false;
            }
        }

        public void Reset() {
            actionLocked = false;
            enabled = true;
            atb = 0.0f;
        }

        private void OnEnable() {

            //// If this character has just acted
            //if (atb > AtbMax && this.combatant.Actions.ActionCount == 0) {
            //    atb = 0.0f;
            //    actionLocked = false;
            //}
        }
    }
}
