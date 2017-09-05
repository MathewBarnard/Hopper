using Assets.Source.Battle.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {
    public abstract class Ability {

        /// <summary>
        /// Returns a list of the actions to be performed. We perform reflection later to allow us to infer the type of each
        /// action at the point of attaching the script to the player.
        /// </summary>
        /// <returns></returns>
        public abstract Type[] GetActions();
    }
}
