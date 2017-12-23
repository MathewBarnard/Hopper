using Assets.Source.Battle.Events;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Actions.Miscellaneous {
    public class TurnFinished : ActorAction {

        private void Start() {
            BattleEventManager.Instance().AbilityCompleted(this.combatant, this.abilitySelection.ability);
            this.complete = true;
        }
    }
}
