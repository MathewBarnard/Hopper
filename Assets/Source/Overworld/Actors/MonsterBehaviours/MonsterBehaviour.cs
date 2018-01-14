using Assets.Source.Overworld.Actors.MonsterBehaviours.Triggers;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.MonsterBehaviours {
    public class MonsterBehaviour : MonoBehaviour {

        protected Actor actor;
        public BehaviourTrigger Trigger;
        public int Priority;

        public void Awake() {
            this.actor = GetComponent<Actor>();
        }

        public virtual HexTile NextDestination() {
            return actor.InhabitedNode;
        }

        public bool IsTriggered() {
            bool result = true;
            if (Trigger != null) {
                result = Trigger.IsTriggered();
            }

            return result;
        }
    }
}
