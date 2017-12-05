using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Actions.Miscellaneous {
    public class TurnFinished : CombatAction {

        private void Start() {
            BattleEventManager.Instance().AbilityCompleted(this.combatant, this.ability);
            this.complete = true;
        }
    }
}
