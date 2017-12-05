using Assets.Source.Battle.Actions.Movement;
using Assets.Source.Battle.Cameras.Behaviours;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras {
    public class CameraController : MonoBehaviour {

        public GameObject cameraAnchors;
        private GameObject targetPosition;
        private Quaternion targetRotation;

        private void Awake() {
            BattleEventManager.Instance().onBeginActionSelection += SelectActionCamera;
            BattleEventManager.Instance().onActionSelected += SelectTargetCamera;
            BattleEventManager.Instance().onTargetSelected += ReturnToRest;
        }

        private void FixedUpdate() {
            this.transform.position = Vector3.Lerp(transform.position, targetPosition.transform.position, Time.deltaTime * 3.0f);
        }

        // The camera behaviour when a character is selecting their action.
        private void SelectActionCamera(Combatant combatant, Combatant previous) {
            this.targetPosition = cameraAnchors.transform.Find("PlayersFocus").gameObject;
        }

        // The camera behaviour when a character is targeting an enemy
        public void SelectTargetCamera(Combatant actingCombatant, Ability selectedAbility) {
            this.targetPosition = cameraAnchors.transform.Find("EnemiesFocus").gameObject;
        }

        public void ReturnToRest(List<Combatant> combatants) {
            this.targetPosition = cameraAnchors.transform.Find("Rest").gameObject;
        }
    } 
}
