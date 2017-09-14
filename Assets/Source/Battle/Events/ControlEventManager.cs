using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Events {

    public delegate void CombatantClicked(Combatant combatant);

    public class ControlEventManager {

        public CombatantClicked onCombatantClicked;

        private static ControlEventManager controlEventManager;

        public static ControlEventManager Instance() {
            if (controlEventManager == null) {
                controlEventManager = new ControlEventManager();
            }

            return controlEventManager;
        }

        public void CombatantClicked(Combatant combatant) {
            if (onCombatantClicked != null)
                onCombatantClicked.Invoke(combatant);
        }

    }
}
