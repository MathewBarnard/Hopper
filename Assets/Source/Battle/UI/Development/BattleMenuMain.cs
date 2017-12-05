using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI.Development {
    public class BattleMenuMain : MonoBehaviour {

        public Text momentumText;
        private Combatant actingCombatant;
        private int momentum;

        private void Awake() {
            //BattleEventManager.Instance().onBeginActionSelection += MoveToCombatant;
            BattleEventManager.Instance().onTargetingCancelled += Enable;
            momentum = 0;
        }

        public void SetActingCombatant(Combatant combatant) {
            this.actingCombatant = combatant;

            // Move to the combatant
        }

        public void AttackSelected() {
            Ability ability = actingCombatant.Spellbook.All.Where(abl => abl.abilityType == Spells.AbilityType.attackmelee).FirstOrDefault();
            ability.ApplyMomentum(momentum);
            BattleEventManager.Instance().ActionSelected(actingCombatant, ability);
            this.gameObject.SetActive(false);
        }

        public void TechSelected() {
            Ability ability = actingCombatant.Spellbook.All.Where(abl => abl.abilityType == Spells.AbilityType.ember).FirstOrDefault();
            ability.MomentumApplied = momentum;
            BattleEventManager.Instance().ActionSelected(actingCombatant, ability);
            this.gameObject.SetActive(false);
        }

        public void ItemSelected() {
            this.gameObject.SetActive(false);
        }

        public void Enable() {
            this.gameObject.SetActive(true);
        }

        public void IncreaseMomentum() {
            if(momentum < 6) {
                momentum++;
            }

            this.momentumText.text = momentum.ToString();
        }

        public void DecreaseMomentum() {
            if(momentum > 0) {
                momentum--;
            }

            this.momentumText.text = momentum.ToString();
        }
    }
}
