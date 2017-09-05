using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Actions {
    interface ITargetedAction {
        void SetTarget(Combatant combatant);
    }
}
