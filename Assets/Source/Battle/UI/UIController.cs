using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.UI.Development;
using UnityEngine;
using Assets.Source.Battle.UI.Callbacks;
using System.Collections.Generic;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;

namespace Assets.Source.Battle.UI {
    public class UIController : MonoBehaviour {

        public BattleMenuMain menuAnchor;

        private void Awake() {
            BattleEventManager.Instance().onBeginTurn += ShowMenu;
        } 

        public void ShowMenu(Combatant combatant) {
            if(combatant is PlayerCombatant) {
                this.menuAnchor.gameObject.SetActive(true);
                this.menuAnchor.SetActingCombatant(combatant);
            }
        }

        public void ShowTargetingReticule(Ability ability) {

        }
    }
}
