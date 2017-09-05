using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Actions.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {
    public class AttackMelee : Ability {

        public override Type[] GetActions() {

            Type[] actions = new Type[3];

            actions[0] = typeof(MoveToCombatant);
            actions[1] = typeof(Actions.Attacks.AttackMelee);
            actions[2] = typeof(MoveToLocation);

            return actions;
        }
    }
}
