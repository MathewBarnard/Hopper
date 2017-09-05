using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Startup {
    public class UnitPlacement : MonoBehaviour {

        public List<Transform> playerLocations;
        public List<Transform> enemyLocations;

        public void PlacePlayers(List<GameObject> players) {

            for(int i = 0; i < players.Count; i++) {
                players[i].transform.position = playerLocations[i].transform.position;
                players[i].transform.rotation = playerLocations[i].transform.rotation;
            }
        }

        public void PlaceEnemies(List<GameObject> enemies) {

            for (int i = 0; i < enemies.Count; i++) {
                enemies[i].transform.position = enemyLocations[i].transform.position;
                enemies[i].transform.rotation = enemyLocations[i].transform.rotation;
            }
        }
    }
}
