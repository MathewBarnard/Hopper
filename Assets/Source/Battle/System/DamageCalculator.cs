using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.System {
    public static class DamageCalculator {

        public static AbilityResult CalculatePhysicalDamage(Combatant attacker, Combatant defender) {

            Statistics attackerStats = attacker.GetStats();
            Statistics defenderStats = defender.GetStats();

            int damage = attackerStats.Attack.Current - (defenderStats.Defense.Current / 2);

            defenderStats.Health.Current -= damage;

            return new AbilityResult(defender, damage);
        }

        public static AbilityResult CalculatePhysicalDamage(Combatant attacker, Combatant defender, int attackModifier) {

            Statistics attackerStats = attacker.GetStats();
            Statistics defenderStats = defender.GetStats();

            int damage = ((attackerStats.Attack.Current / 100) * attackModifier) - (defenderStats.Defense.Current / 2);

            defenderStats.Health.Current -= damage;

            return new AbilityResult(defender, damage);
        }

        public static AbilityResult CalculateHealing(Combatant healer, Combatant target, int magicModifier) {

            Statistics casterStats = healer.GetStats();

            int healAmount = 59;

            return new AbilityResult(target, healAmount);
        }
    }
}
