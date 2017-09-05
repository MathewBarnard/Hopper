using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Events {

    // Events handling occurances during battle
    public delegate void CombatantKilled(Combatant combatant);
    public delegate void CombatantDamaged(Combatant combatant);
    public delegate void CombatantTargeted(Combatant targetedCombatant, Combatant targetedBy);
    public delegate void CombatantAtbFull(Combatant combatant);

    // Events handling battle states.
    public delegate void BattleTriggered();
    public delegate void BattleStart();
    public delegate void BattleEnd();
    public delegate void BattleResume();

    public delegate void CombatantActionSelected(Combatant combatant);

    public class BattleEventManager {

        public BattleTriggered onBattleTriggered;
        public BattleStart onBattleStart;
        public BattleEnd onBattleEnd;
        public BattleResume onBattleResume;
        public CombatantActionSelected onCombatantActionSelected;

        public CombatantKilled onCombatantKilled;
        public CombatantDamaged onCombatantDamaged;
        public CombatantTargeted onCombatantTargeted;
        public CombatantAtbFull onCombatantAtbFull;

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

        public void CombatantKilled(Combatant combatant) {
            if (onCombatantKilled != null)
                onCombatantKilled.Invoke(combatant);
        }

        public void CombatantHit(Combatant combatant) {
            if (onCombatantDamaged != null)
                onCombatantDamaged.Invoke(combatant);
        }

        public void CombatantTargeted(Combatant targetedCombatant, Combatant targetedBy) {
            if (onCombatantTargeted != null)
                onCombatantTargeted.Invoke(targetedCombatant, targetedBy);
        }

        public void CombatantAtbFull(Combatant combatant) {
            if (onCombatantAtbFull != null)
                onCombatantAtbFull.Invoke(combatant);
        }

        public void CombatantActionSelected(Combatant combatant) {
            if (onCombatantActionSelected != null)
                onCombatantActionSelected.Invoke(combatant);
        }
    }
}
