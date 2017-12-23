using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {
    public class TargetedSelector : MonoBehaviour {

        public Animator animator;
        public Combatant combatant;
        public Ability ability;

        public void Highlight(bool flag) {
            this.gameObject.SetActive(flag);
        }

        void Awake() {

            this.animator = this.gameObject.GetComponent<Animator>();

            BattleEventManager.Instance().onActionSelected += CheckIfTargetable;
            BattleEventManager.Instance().onTargetSelected += Disable;

            this.gameObject.SetActive(false);
        }

        private void OnMouseOver() {
            this.animator.SetBool("isHighlighted", true);
        }

        private void OnMouseExit() {
            this.animator.SetBool("isHighlighted", false);
        }

        public void CheckIfTargetable(Combatant combatant, Ability ability) {

            this.ability = ability;

            // If this is a player targetter, only check defensive abilities.
            if(this.combatant is PlayerCombatant) {

                if(ability.TargetingType() == TargetingType.DEFENSIVE_ALL || ability.TargetingType() == TargetingType.DEFENSIVE_SINGLE) {
                    Enable();
                }
            }
            else {
                if(ability.TargetingType() == TargetingType.OFFENSIVE_ALL || ability.TargetingType() == TargetingType.OFFENSIVE_SINGLE) {
                    Enable();
                }
            }
        }

        public void Enable() {
            this.gameObject.SetActive(true);
        }

        public void Disable(List<Combatant> targets) {

            this.ability = null;
            this.gameObject.SetActive(false);
        }

        public void OnDestroy() {
            BattleEventManager.Instance().onActionSelected -= CheckIfTargetable;
            BattleEventManager.Instance().onTargetSelected -= Disable;
        }
    }
}
