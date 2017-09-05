using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Cameras;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using Assets.Source.Battle.UI;
using Assets.Source.Battle.UI.Callbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.StateProcesses {

    public class BattleStateController : MonoBehaviour {

        public UIController uiController;
        public CameraController cameraController;

        private void Awake() {
            BattleEventManager.Instance().onCombatantAtbFull += EnterCharacterTurnState;
        }

        /// <summary>
        /// Called when we begin the characters turn.
        /// </summary>
        /// <param name="combatant"></param>
        public void EnterCharacterTurnState(Combatant combatant) {

            if (combatant is PlayerCombatant) {
                PauseController.Instance().PauseAllButOne(combatant);
                cameraController.LookAtTargetAdjacent(combatant.gameObject);
                uiController.GenerateSelectActionUI(combatant, new CombatantWithString(EnterSelectTargetState));
            }
        }

        /// <summary>
        /// Triggered via a callback from the UI when the user has selected an action.
        /// </summary>
        /// <param name="ability"></param>
        public void EnterSelectTargetState(Combatant combatant, string ability) {
            cameraController.MoveToAnchor("SelectTarget");
            ActionAttacher.AttachScriptsForAbility(combatant, Spellbook.CreateAbility(ability));
            uiController.GenerateSelectTargetUI(combatant, new CombatantWithGameObject(TargetSelected));
        }

        public void TargetSelected(Combatant combatant, GameObject target) {
            uiController.Clear();
            combatant.Target = target.GetComponent<Combatant>();
            //BattleEventManager.Instance().CombatantTargeted(target.GetComponent<Combatant>(), combatant);
            PauseController.Instance().UnPause();
        }
    }
}
