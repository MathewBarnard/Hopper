using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Engine.GameStates.Transitions {

    public enum GameState { Overworld, Battle }

    public struct GameStateContainer {
        private GameState state;
        public GameState State {
            get { return state; }
            set { state = value; }
        }
        private GameObject container;
        public GameObject Container {
            get { return container; }
            set { container = value; }
        }
    }

    public class TransitionManager : MonoBehaviour {

        private Stack<GameStateContainer> hibernatingGameStates;
        private GameStateContainer currentGameState;

        public TransitionManager() {
            this.hibernatingGameStates = new Stack<GameStateContainer>();
        }

        internal void RegisterGameState(GameState gameState, GameObject container) {
            this.currentGameState = new GameStateContainer();
            this.currentGameState.State = gameState;
            this.currentGameState.Container = container;
            Debug.Log(string.Format("Registered new game state: {0}", gameState.ToString()));
        }

        /// <summary>
        /// Exit the current game state, and continue replaying the next state that is hibernating.
        /// </summary>
        internal void ExitGameState() {

            // Unload the current scene
            StartCoroutine(UnloadAsyncScene(this.currentGameState.State.ToString()));

            this.currentGameState = this.hibernatingGameStates.Pop();

            this.currentGameState.Container.SetActive(true);
        }

        /// <summary>
        /// Transition to a new GameState.
        /// </summary>
        /// <param name="gameState">The name of the GameState we are transitioning to.</param>
        /// <param name="loadSceneMode">Define whether we add this State on top of the active state, or discard all active states.</param>
        internal void TransitionGameState(GameState gameState, LoadSceneMode loadSceneMode) {
            
            if(loadSceneMode == LoadSceneMode.Single) {
                TransitionState(gameState, loadSceneMode);
            }
            else {
                TransitionStateStoreCurrent(gameState, loadSceneMode);
            }
        }

        private void TransitionState(GameState gameState, LoadSceneMode loadSceneMode) {

            switch (gameState) {
                case GameState.Overworld:
                    StartCoroutine(LoadAsyncScene("Overworld", loadSceneMode));
                    break;

                case GameState.Battle:
                    StartCoroutine(LoadAsyncScene("Battle", loadSceneMode));
                    break;
            }
        }

        private void TransitionStateStoreCurrent(GameState gameState, LoadSceneMode loadSceneMode) {

            // Move the existing state to the stack.
            this.hibernatingGameStates.Push(currentGameState);
            this.currentGameState.Container.SetActive(false);

            TransitionState(gameState, loadSceneMode);
        }

        IEnumerator LoadAsyncScene(string sceneName, LoadSceneMode loadSceneMode) {
            // The Application loads the Scene in the background at the same time as the current Scene.
            //This is particularly good for creating loading screens. You could also load the Scene by build //number.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            //Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone) {
                yield return null;
            }
        }

        IEnumerator UnloadAsyncScene(string sceneName) {

            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);

            while (!asyncUnload.isDone) {
                yield return null;
            }
        }
    }
}
