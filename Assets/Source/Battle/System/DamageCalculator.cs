using Assets.Source.Battle.Combatants;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.System {
    public static class DamageCalculator {

        public static int CalculatePhysicalDamage(Combatant attacker, Combatant defender) {

            Statistics attackerStats = attacker.GetStats();
            Statistics defenderStats = defender.GetStats();

            int damage = attackerStats.Attack.Current - (defenderStats.Defense.Current / 2);

            return damage;
        }
    }
}
