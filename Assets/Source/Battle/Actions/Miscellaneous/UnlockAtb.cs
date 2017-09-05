using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Actions.Miscellaneous {

    public class UnlockAtb : CombatAction {

        private AtbGauge atbGauge;

        public override void Awake() {
            base.Awake();
            atbGauge = this.gameObject.GetComponent<AtbGauge>();
            enabled = false;
        }

        private void Update() {

            atbGauge.Reset();

            complete = true;
        }
    }
}
