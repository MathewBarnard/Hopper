using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {

    public enum TargetingType { DEFENSIVE_SINGLE, DEFENSIVE_ALL, OFFENSIVE_SINGLE, OFFENSIVE_ALL, SELF }

    public abstract class Ability {

        protected TargetingType targetingType;
        public TargetingType TargetingType {
            get { return targetingType; }
        }

        public AbilityType abilityType;
        public abstract AbilityType AbilityType();

        protected List<AbilityLevel> abilityLevels;
        public List<AbilityLevel> AbilityLevels {
            get { return abilityLevels; }
        }

        protected List<Combatant> targets;
        public List<Combatant> Targets {
            get { return targets; }
            set { targets = value; }
        }

        protected Combatant actingCombatant;
        public Combatant ActingCombatant {
            get { return actingCombatant; }
            set { actingCombatant = value; }
        }

        protected int momentumApplied;
        public int MomentumApplied {
            get { return momentumApplied; }
            set { momentumApplied = value; }
        }

        /// <summary>
        /// Returns a list of the actions to be performed. We perform reflection later to allow us to infer the type of each
        /// action at the point of attaching the script to the player.
        /// </summary>
        /// <returns></returns>
        public abstract Type[] GetActions();

        public abstract string Name();

        public abstract void Process();

        public abstract void AttachScripts();

        public abstract void ApplyMomentum(int momentum);
    }
}
