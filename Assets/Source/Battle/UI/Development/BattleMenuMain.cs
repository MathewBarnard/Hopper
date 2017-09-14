using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {
    public class BattleMenuMain : MonoBehaviour {

        private Combatant actingCombatant;
        
        public void SetActingCombatant(Combatant combatant) {
            this.actingCombatant = combatant;
        }

        public void AttackSelected() {
            BattleEventManager.Instance().ActionSelected(actingCombatant, actingCombatant.Spellbook.All.Where(abl => abl.abilityType == Spells.AbilityType.attackmelee).FirstOrDefault());
        }

        public void TechSelected() {

        }

        public void ItemSelected() {

        }
    }
}
