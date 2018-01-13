using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.MonsterBehaviours.Triggers {
    public abstract class BehaviourTrigger : MonoBehaviour {

        // Always returns true. This represents a default trigger at the lowest priority.
        public virtual bool IsTriggered() {
            return true;
        }
    }
}
