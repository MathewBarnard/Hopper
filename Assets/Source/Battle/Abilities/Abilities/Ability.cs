using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities.AbilityResults;
using Assets.Source.Battle.StateProcesses;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities {

    public enum TargetingType { DEFENSIVE_SINGLE, DEFENSIVE_ALL, OFFENSIVE_SINGLE, OFFENSIVE_ALL, SELF }

    public abstract class Ability {

        protected Models.Ability model;
        public Models.Ability Model {
            get { return model; }
        }

        public AbilityType abilityType;
        public abstract AbilityType AbilityType();

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

        public virtual string Name() {
            return this.model.Name;
        }

        public virtual TargetingType TargetingType() {
            return this.model.TargetingType;
        }

        public abstract List<AbilityResult> Process(List<Combatant> targets);

        public abstract void AttachScripts(AbilitySelection abilitySelection);
    }
}
