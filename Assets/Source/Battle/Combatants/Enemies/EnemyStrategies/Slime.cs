using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants.Enemies.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants.Enemies.EnemyStrategies {
    public class Slime : EnemyCombatant {

        public EnemyInRange targetWhenInRange;

        public override void Awake() {
            base.Awake();
        }
    }
}
