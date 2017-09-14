using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.StateProcesses {
    public class PauseController {

        public List<Combatant> combatants;

        public static PauseController pauseController;

        public static PauseController Instance() {
            if(pauseController == null) {
                pauseController = new PauseController();
            }

            return pauseController;
        }

        public PauseController() {
            combatants = new List<Combatant>();
        }

        public void FullPause() {
            foreach(Combatant combatant in combatants) {

                //Disable any active actions
                if (combatant.Actions.CurrentAction != null) {
                    combatant.Actions.CurrentAction.enabled = false;
                }

                Animator animator = combatant.gameObject.GetComponent<Animator>();

                if(animator != null) {
                    animator.enabled = false;
                }
            }
        }

        public void PauseAllButOne(Combatant combatantNotPaused) {

            foreach (Combatant combatant in combatants) {

                if (combatant != combatantNotPaused) {
                    //Disable any active actions
                    if (combatant.Actions.CurrentAction != null) {
                        combatant.Actions.CurrentAction.enabled = false;
                    }

                    Animator animator = combatant.gameObject.GetComponent<Animator>();

                    if (animator != null) {
                        animator.enabled = false;
                    }
                }
            }
        }

        public void UnPause() {
            foreach (Combatant combatant in combatants) {

                //Disable any active actions
                if (combatant.Actions.CurrentAction != null) {
                    combatant.Actions.CurrentAction.enabled = true;
                }

                Animator animator = combatant.gameObject.GetComponent<Animator>();

                if (animator != null) {
                    animator.enabled = true;
                }
            }
        }
    }
}
