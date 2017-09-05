using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {

    public class AtbGauge : MonoBehaviour {

        public GameObject lowerAnchor;
        public GameObject upperAnchor;

        private float distance;

        List<KeyValuePair<PlayerCombatant, GameObject>> playerIcons;
        List<KeyValuePair<EnemyCombatant, GameObject>> enemyIcons;

        private void Start() {

            playerIcons = new List<KeyValuePair<PlayerCombatant, GameObject>>();
            enemyIcons = new List<KeyValuePair<EnemyCombatant, GameObject>>();

            distance = upperAnchor.transform.position.x - lowerAnchor.transform.position.x;

            List<PlayerCombatant> combatants = GameObject.FindObjectsOfType<PlayerCombatant>().ToList();

            List<EnemyCombatant> enemyCombatants = GameObject.FindObjectsOfType<EnemyCombatant>().ToList();

            foreach (PlayerCombatant combatant in combatants) {
                playerIcons.Add(new KeyValuePair<PlayerCombatant, GameObject>(combatant, Instantiate((GameObject)Resources.Load("Prefabs/Battle/Development/AtbGaugeUI/PlayerIcon"), this.gameObject.transform)));
            }

            foreach(EnemyCombatant enemyCombatant in enemyCombatants) {
                enemyIcons.Add(new KeyValuePair<EnemyCombatant, GameObject>(enemyCombatant, Instantiate((GameObject)Resources.Load("Prefabs/Battle/Development/AtbGaugeUI/EnemyIcon"), this.gameObject.transform)));
            }
        }

        private void Update() {
            
            foreach(KeyValuePair<PlayerCombatant,GameObject> icon in playerIcons) {
                icon.Value.transform.position = new Vector3(lowerAnchor.gameObject.transform.position.x + ((distance / 100) * icon.Key.AtbGauge.Atb),
                                                            lowerAnchor.gameObject.transform.position.y,
                                                            lowerAnchor.gameObject.transform.position.z);
            }

            Debug.Log(enemyIcons.Count);

            foreach (KeyValuePair<EnemyCombatant, GameObject> icon in enemyIcons) {
                icon.Value.transform.position = new Vector3(lowerAnchor.gameObject.transform.position.x + ((distance / 100) * icon.Key.AtbGauge.Atb),
                                                            lowerAnchor.gameObject.transform.position.y,
                                                            lowerAnchor.gameObject.transform.position.z);
            }
        } 
    }
}
