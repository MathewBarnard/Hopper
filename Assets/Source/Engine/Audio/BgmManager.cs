using Assets.Source.Engine.GameStates.Transitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Engine.Audio {
    public class BgmManager : MonoBehaviour {

        public static BgmManager instance;

        public void Awake() {
            EngineEventManager.Instance().onTransitionGameState += CheckState;
            EngineEventManager.Instance().onGameStateExit += CheckState;
            DontDestroyOnLoad(this.gameObject);
        }

        public AudioSource battleMusic;

        public void CheckState() {
            StopBattleMusic();
        }

        public void CheckState(GameState gameState, LoadSceneMode loadSceneMode) {
            Debug.Log("Checking audio state");
            if(gameState == GameState.Battle) {
                PlayBattleMusic();
            }

            if(gameState == GameState.Overworld) {
                StopBattleMusic();
            }
        }

        public void PlayBattleMusic() {
            battleMusic.Play();
        }

        public void StopBattleMusic() {
            battleMusic.Stop();
        }
    }
}
