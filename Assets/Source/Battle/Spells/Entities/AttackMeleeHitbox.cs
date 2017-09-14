using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells.Entities {
    public class AttackMeleeHitbox : OffensiveSpell {

        public override void ProcessEffect(Combatant hit) {

            // Deal physical damage to the target
            int damage = DamageCalculator.CalculatePhysicalDamage(source, hit);

            hit.GetStats().Health.Current -= damage;

            BattleEventManager.Instance().EndTurn();
        }
    }
}
