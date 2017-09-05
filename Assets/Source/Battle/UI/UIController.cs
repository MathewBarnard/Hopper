using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.UI.Development;
using UnityEngine;
using Assets.Source.Battle.UI.Callbacks;
using System.Collections.Generic;

namespace Assets.Source.Battle.UI {
    public class UIController : MonoBehaviour {

        public GameObject menuAnchor;

        private BattleUiComponent currentUi;

        public void GenerateSelectActionUI(Combatant combatant, CombatantWithString callback) {

            if(this.currentUi != null) {
                Destroy(currentUi);
            }

            SelectActionMenu selectActionMenu = this.gameObject.AddComponent<SelectActionMenu>();
            selectActionMenu.Callback = callback;
            selectActionMenu.UiController = this;
            selectActionMenu.Combatant = combatant;
            this.currentUi = selectActionMenu;
        }

        public void GenerateSelectTargetUI(Combatant combatant, CombatantWithGameObject callback) {

            if (this.currentUi != null) {
                Destroy(currentUi);
            }

            SelectTargetMenu selectTargetMenu = this.gameObject.AddComponent<SelectTargetMenu>();
            selectTargetMenu.Callback = callback;
            selectTargetMenu.UiController = this;
            selectTargetMenu.Combatant = combatant;
            this.currentUi = selectTargetMenu;
        }

        public void Clear() {
            Destroy(this.currentUi);
            this.currentUi = null;
        }
    }
}
