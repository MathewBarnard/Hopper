using Assets.Source.Battle.Startup;
using Assets.Source.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Development {
    public class LoadBattle : MonoBehaviour {

        public string enemyPartyName;

        void Update() {

            if(UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.W)) {
                BattleTransitionContainer.EnemyParty = DataRepository.Instance().Parties.GetByName(enemyPartyName);
                SceneManager.LoadSceneAsync("Battle");
            }
        }
    }
}
