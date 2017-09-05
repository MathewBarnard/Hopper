using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Combatants {
    public class EnemyCombatant : Combatant {

        private Enemy enemy;
        public Enemy Enemy {
            get { return enemy; }
            set { enemy = value; }
        }

        private void Awake() {
            base.Awake();
        }
    }
}
