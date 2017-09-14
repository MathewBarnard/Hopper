using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells {
    public abstract class SpellHitbox : MonoBehaviour {

        public Combatant source;

        public virtual void ProcessEffect(Combatant hit) {
            Debug.Log("Process effect");
        }
    }
}
