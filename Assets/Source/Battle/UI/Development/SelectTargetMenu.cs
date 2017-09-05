using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.UI.Callbacks;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {
    public class SelectTargetMenu : BattleUiComponent {

        private CombatantWithGameObject callback;
        public CombatantWithGameObject Callback {
            set { callback = value; }
        }

        private UIController uiController;
        public UIController UiController {
            set { uiController = value; }
        }

        private Combatant combatant;
        public Combatant Combatant {
            set { combatant = value; }
        }

        private void Start() {
            this.artifacts = new List<GameObject>();
        }

        private void Update() {

            // Check for a user click on an enemy
            if(UnityEngine.Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit)) {

                    EnemyCombatant enemy = hit.transform.gameObject.GetComponent<EnemyCombatant>();

                    if (enemy != null) {
                        TargetSelected(this.combatant, enemy.gameObject);
                    }
                }
            }
        }

        void TargetSelected(Combatant combatant, GameObject target) {
            callback(combatant, target);
        }
    }
}
