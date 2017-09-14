using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {

    public enum TargetingType { Single, Multiple, All }

    public abstract class Ability {

        protected TargetingType targetingType;
        public TargetingType TargetingType {
            get { return targetingType; }
        }

        public AbilityType abilityType;
        public abstract AbilityType AbilityType();

        protected Combatant actingCombatant;
        public Combatant ActingCombatant {
            get { return actingCombatant; }
            set { actingCombatant = value; }
        }

        /// <summary>
        /// Returns a list of the actions to be performed. We perform reflection later to allow us to infer the type of each
        /// action at the point of attaching the script to the player.
        /// </summary>
        /// <returns></returns>
        public abstract Type[] GetActions();

        public abstract string Name();
    }
}
