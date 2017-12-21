using Assets.Source.Engine.GameStates.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Engine {
    /// <summary>
    /// Represents the overall container for a scene.
    /// </summary>
    public class SceneContainer : MonoBehaviour {

        public GameState gameState;

        private void Start() {
            EngineEventManager.Instance().GameStateTransitionFinished(gameState, this.gameObject);
        }
    }
}
