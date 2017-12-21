using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Startup {

    /// <summary>
    /// A container that holds any relevant information required to be pulled in by the battle post-transition.
    /// </summary>
    public class BattleTransitionContainer {

        private static Party enemyParty;
        public static Party EnemyParty {
            get { return enemyParty; }
            set { enemyParty = value; }
        }
    }
}
