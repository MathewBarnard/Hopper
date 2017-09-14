using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants.Enemies {

    public delegate void Trigger();

    public abstract class EnemyBehaviour : MonoBehaviour  {

        public Trigger trigger;

        public AbilityType abilityType;

        /// <summary>
        /// The ability to trigger when this condition is met.
        /// </summary>
        protected Ability ability;

        /// <summary>
        /// The priority of this 
        /// </summary>
        public int priority;

        /// <summary>
        /// A flag that indicates whether the ability associated with this behaviour can be interrupted if a higher priority triggers.
        /// </summary>
        public bool canBeOverridden;

        protected virtual void Trigger() {
            Debug.Log("Behaviour triggered");
        }
    }
}
