using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants {
    public class EnemyCombatant : Combatant {

        private Models.Enemy enemy;
        public Models.Enemy Enemy {
            get { return enemy; }
            set {
                enemy = value;
                this.spellbook = new Spellbook(this, this.enemy.Abilities);
            }
        }

        public override Models.Statistics GetStats() {
            return this.enemy.Stats;
        }
    }
}
