using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Battle.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells.Entities {

    class HealAnimation : SpellAnimation {

        public void ShowDamage() {
            this.SpawnNumber(this.abilitySelection.results.Where(result => result.Target == this.target).FirstOrDefault().Result, this.target.transform.position, Color.green);
        }
    }
}
