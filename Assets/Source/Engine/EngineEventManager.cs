using Assets.Source.Engine.GameStates.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Engine {

    public delegate void GameStateTransition(GameState gameState, LoadSceneMode loadSceneMode);
    public delegate void GameStateTransitionFinished(GameState gameState, GameObject container);
    public delegate void GameStateExit();

    public class EngineEventManager {

        private static EngineEventManager engineEventManager;

        public GameStateTransition onTransitionGameState;
        public GameStateTransitionFinished onGameStateTransitionFinished;
        public GameStateExit onGameStateExit;

        public static EngineEventManager Instance() {
            if (engineEventManager == null) {
                engineEventManager = new EngineEventManager();
            }
            return engineEventManager;
        }

        public void TransitionGameState(GameState gameState, LoadSceneMode loadSceneMode) {
            if (onTransitionGameState != null) 
                onTransitionGameState.Invoke(gameState, loadSceneMode);
        }

        public void GameStateTransitionFinished(GameState gameState, GameObject container) {
            if (onGameStateTransitionFinished != null)
                onGameStateTransitionFinished.Invoke(gameState, container);
        }

        public void GameStateExit() {
            if (onGameStateExit != null)
                onGameStateExit.Invoke();
        }
    }
}
