using Assets.Source.Battle.Combatants;
using UnityEngine;
using Assets.Source.Battle.UI.Callbacks;
using System.Collections.Generic;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.UI;

namespace Assets.Source.Battle.UI {
    public class UIController : MonoBehaviour {

        public static UIController instance;
        public Canvas overlayCanvas;
        public Canvas mainCanvas;
        public BattleMenu menuAnchor;

        private void Awake() {
            UIController.instance = this;
            BattleEventManager.Instance().onBeginActionSelection += ShowMenu;
        } 

        public void ShowMenu(Combatant combatant, Combatant previous) {
            if(combatant is PlayerCombatant) {
                this.menuAnchor.gameObject.SetActive(true);
                this.menuAnchor.SetActingCombatant(combatant);
            }
        }

        public void ShowTargetingReticule(Ability ability) {

        }

        public void OnDestroy() {
            BattleEventManager.Instance().onBeginActionSelection -= ShowMenu;
        }
    }
}
