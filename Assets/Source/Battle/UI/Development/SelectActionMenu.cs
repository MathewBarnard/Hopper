using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.StateProcesses;
using Assets.Source.Battle.UI.Callbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI.Development {
    public class SelectActionMenu : BattleUiComponent {

        private CombatantWithString callback;
        public CombatantWithString Callback {
            set { callback = value; }
        }

        private UIController uiController;
        public UIController UiController {
            set { uiController = value; }
        }

        private Camera camera;
        public Camera Camera {
            get { return camera; }
        }

        private Combatant combatant;
        public Combatant Combatant {
            set { combatant = value; }
        }

        private void Start() {

            this.artifacts = new List<GameObject>();

            GameObject selectActionButton = Resources.Load("Prefabs/Battle/Development/SelectActionButton") as GameObject;

            PlayerCombatant player = combatant as PlayerCombatant;

            foreach (string ability in player.Character.Spells) {
                GameObject obj = GameObject.Instantiate(selectActionButton, uiController.menuAnchor.transform);
                obj.GetComponent<Button>().onClick.AddListener(() => this.ActionSelected(this.combatant, ability));
                obj.GetComponentInChildren<Text>().text = ability;
                this.artifacts.Add(obj);
            }
        }

        void ActionSelected(Combatant combatant, string abilityName) {
            callback(combatant, abilityName);
        }
    }
}
