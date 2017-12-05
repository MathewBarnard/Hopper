using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.StateProcesses {
    public class TurnController {

        private int index;
        private List<KeyValuePair<Combatant, Ability>> abilitySelections;

        public TurnController(List<KeyValuePair<Combatant, Ability>> abilitySelections) {
            this.abilitySelections = abilitySelections;
            this.index = 0;
            BattleEventManager.Instance().onAbilityCompleted += BeginNextAction;

            BeginNextAction();
        }

        public void BeginNextAction() {
            
            // End the turn if we have processed all abilities
            if(index == abilitySelections.Count) {
                this.index = 0;
                this.abilitySelections = null;
                BattleEventManager.Instance().onAbilityCompleted -= BeginNextAction;
                BattleEventManager.Instance().EndTurn();
            } 
            // Process the ability
            else {
                abilitySelections[index].Value.Process();
                abilitySelections[index].Value.AttachScripts();
                index++;
            }
        }

        public void BeginNextAction(Combatant combatant, Ability ability) {
            this.BeginNextAction();
        }
    }
}
