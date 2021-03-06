﻿using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Events {

    // Events handling occurances during battle
    public delegate void CombatantKilled(Combatant combatant);
    public delegate void CombatantDamaged(Combatant combatant);
    public delegate void AbilityCompleted(Combatant combatant, Ability ability);

    // Events handling battle states.
    public delegate void BattleTriggered();
    public delegate void BattleStart();
    public delegate void BattleEnd();
    public delegate void BattleResume();

    // Turn flow events
    public delegate void BeginTurn(Combatant combatant);
    public delegate void BeginActionSelection(Combatant nextCombatant, Combatant previousCombatant);
    public delegate void ActionSelected(Combatant combatant, Ability ability);
    public delegate void TargetChanged(Combatant oldTarget, Combatant newTarget);
    public delegate void TargetSelected(List<Combatant> targets);
    public delegate void TargetingCancelled();
    public delegate void BeginPlayTurn();
    public delegate void EndTurn();

    public class BattleEventManager {

        public BattleTriggered onBattleTriggered;
        public BattleStart onBattleStart;
        public BattleEnd onBattleEnd;
        public BattleResume onBattleResume;

        public BeginTurn onBeginTurn;
        public BeginActionSelection onBeginActionSelection;
        public ActionSelected onActionSelected;
        public TargetChanged onTargetChanged;
        public TargetingCancelled onTargetingCancelled;
        public TargetSelected onTargetSelected;
        public BeginPlayTurn onBeginPlayTurn;
        public EndTurn onEndTurn;

        public CombatantKilled onCombatantKilled;
        public CombatantDamaged onCombatantDamaged;
        public AbilityCompleted onAbilityCompleted;


        private static BattleEventManager battleEventManager;

        public static BattleEventManager Instance() {
            if (battleEventManager == null) {
                battleEventManager = new BattleEventManager();
            }

            return battleEventManager;
        }

        public void BattleTriggered() {
            if(onBattleTriggered != null)
                onBattleTriggered.Invoke();
        }

        public void BattleStart() {
            if (onBattleStart != null)
                onBattleStart.Invoke();
        }

        public void BattleEnd() {
            if (onBattleEnd != null)
                onBattleEnd.Invoke();
        }

        public void BattleResume() {
            if (onBattleResume != null)
                onBattleResume.Invoke();
        }

        public void BeginTurn(Combatant combatant) {
            if(onBeginTurn != null) {
                onBeginTurn.Invoke(combatant);
            }
        }

        public void CombatantKilled(Combatant combatant) {
            if (onCombatantKilled != null)
                onCombatantKilled.Invoke(combatant);
        }

        public void CombatantHit(Combatant combatant) {
            if (onCombatantDamaged != null)
                onCombatantDamaged.Invoke(combatant);
        }

        public void AbilityCompleted(Combatant combatant, Ability ability) {
            if (onAbilityCompleted != null)
                onAbilityCompleted.Invoke(combatant, ability);
        }

        public void BeginActionSelection(Combatant nextCombatant, Combatant previousCombatant) {
            if (onBeginActionSelection != null)
                onBeginActionSelection.Invoke(nextCombatant, previousCombatant);
        }

        public void ActionSelected(Combatant combatant, Ability ability) {
            if (onActionSelected != null)
                onActionSelected.Invoke(combatant, ability);
        }

        public void TargetChanged(Combatant oldTarget, Combatant newTarget) {
            if (onTargetChanged != null)
                onTargetChanged.Invoke(oldTarget, newTarget);
        }

        public void TargetSelected(List<Combatant> targets) {
            if (onTargetSelected != null) {
                onTargetSelected.Invoke(targets);
            }
        }

        public void TargetingCancelled() {
            if (onTargetingCancelled != null)
                onTargetingCancelled.Invoke();
        }

        public void BeginPlayTurn() {
            if (onBeginPlayTurn != null)
                onBeginPlayTurn.Invoke();
        }

        public void EndTurn() {
            if(onEndTurn != null) {
                onEndTurn.Invoke();
            }
        }
    }
}
