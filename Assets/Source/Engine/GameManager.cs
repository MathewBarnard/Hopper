using Assets.Source.DataAccessLayer;
using Assets.Source.Engine.GameStates.Transitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Engine {
    public class GameManager : MonoBehaviour {

        public TransitionManager transitionManager;

        private void Awake() {
            DontDestroyOnLoad(this.gameObject);
            this.transitionManager = this.gameObject.GetComponent<TransitionManager>();
            EngineEventManager.Instance().onTransitionGameState += TransitionGameState;
            EngineEventManager.Instance().onGameStateTransitionFinished += RegisterGameState;
            EngineEventManager.Instance().onGameStateExit += ExitCurrentState;
        }

        // Use this for initialization
        void Start() {
            // Boot up the data repository.
            DataRepository repository = DataRepository.Instance();
        }

        void TransitionGameState(GameState gameState, LoadSceneMode loadSceneMode) {
            // At the moment, the game manager doesnt need to know any of these juicy details. Just pass on the message
            this.transitionManager.TransitionGameState(gameState, loadSceneMode);
        }

        void RegisterGameState(GameState gameState, GameObject container) {
            this.transitionManager.RegisterGameState(gameState, container);
        }

        void ExitCurrentState() {
            this.transitionManager.ExitGameState();
        }
    }
}
