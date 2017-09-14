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
        }
    }
}
