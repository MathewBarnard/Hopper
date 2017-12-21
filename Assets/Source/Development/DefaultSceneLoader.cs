using Assets.Source.Battle.Startup;
using Assets.Source.DataAccessLayer;
using Assets.Source.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Development {
    
    public enum DefaultScene { Overworld, Battle };

    /// <summary>
    /// Used to load an initial scene for debugging. We might need to supply some form of initial setup that would normally be handled by a transition.
    /// </summary>
    public class DefaultSceneLoader : MonoBehaviour {

        public DefaultScene defaultScene;
        public string enemyPartyName;

        void Update() {

            if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.W)) {

                switch(defaultScene) {
                    case DefaultScene.Overworld:
                        EngineEventManager.Instance().onTransitionGameState(Engine.GameStates.Transitions.GameState.Overworld, LoadSceneMode.Single);
                        break;
                    case DefaultScene.Battle:
                        BattleTransitionContainer.EnemyParty = DataRepository.Instance().Parties.GetByName(enemyPartyName);
                        SceneManager.LoadSceneAsync("Battle");
                        break;
                }
            }
        }

        private void LoadBattle() {

        }

        private void LoadOverworld() {

        }
    }
}
