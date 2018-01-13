using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.MonsterBehaviours {
    public class BehaviourSet : MonoBehaviour {

        private MonsterParty monsterParty;
        public List<MonsterBehaviour> behaviours;

        private MonsterBehaviour activeBehaviour;
        public MonsterBehaviour ActiveBehaviour {
            get { return activeBehaviour; }
        }

        public void Awake() {
            monsterParty = this.GetComponent<MonsterParty>();
            OverworldEventManager.Instance().onStartTurn += DetermineBehaviours;
        }

        public void DetermineBehaviours() {

            List<MonsterBehaviour> behavioursByPriority = behaviours.OrderBy(b => b.Priority).ToList();

            foreach(MonsterBehaviour behaviour in behavioursByPriority) {
                if(behaviour.IsTriggered()) {
                    activeBehaviour = behaviour;
                    continue;
                }
            }
        }

        /// <summary>
        /// This returns the 
        /// </summary>
        /// <returns></returns>
        public HexTile NextDestination() {

            return activeBehaviour.NextDestination();
        }
    }
}
