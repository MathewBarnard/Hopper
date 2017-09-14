//using Assets.Source.Battle.Actions;
//using Assets.Source.Battle.Actions.Movement;
//using Assets.Source.Battle.Combatants;
//using Assets.Source.Battle.Events;
//using Assets.Source.Battle.UI.Development;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Source.Battle.Controls.Development {
//    public class CombatantController : MonoBehaviour {

//        public HighlightedCircle controllerUi;

//        private Combatant combatant;

//        private bool selected;

//        private float clickTimer;

//        private void Awake() {
//            this.selected = false;
//            this.combatant = this.gameObject.GetComponent<Combatant>();
//        }

//        private void Update() {

//            if(!selected) { 
//                if (UnityEngine.Input.GetMouseButtonDown(0)) {
//                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                    RaycastHit hit;

//                    if (Physics.Raycast(ray, out hit)) {

//                        if (hit.transform.gameObject == this.gameObject) {
//                            ControlEventManager.Instance().CombatantClicked(this.gameObject.GetComponent<Combatant>());
//                            selected = true;

//                            //Activate UI object
//                            this.controllerUi.Highlight(true);
//                            this.controllerUi.Select(true);
//                        }
//                    }
//                }
//            }
//            else {

//                if(UnityEngine.Input.GetMouseButtonUp(0)) {

//                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//                    RaycastHit hit;

//                    if (Physics.Raycast(ray, out hit)) {

//                        Combatant potentialTarget = hit.transform.gameObject.GetComponent<Combatant>();

//                        if(potentialTarget == this.combatant) {
//                            Debug.Log("Combatant context menu");
//                        }
//                        else if (potentialTarget != null) {
//                            this.combatant.Target = potentialTarget;
//                            ActionAttacher.AttachScriptsForAbility(combatant, combatant.OffensiveAbility);
//                            this.combatant.ActiveAbility = combatant.OffensiveAbility;


//                            //Activate UI object
//                            this.controllerUi.Highlight(false);
//                            this.controllerUi.Select(false);
//                        }
//                        else {
//                            MoveToLocation moveAction = combatant.gameObject.AddComponent<MoveToLocation>();
//                            moveAction.TargetLocation = hit.point;
//                            combatant.Target = null;
//                            combatant.Actions.SetAction(moveAction);


//                            //Activate UI object
//                            this.controllerUi.Highlight(false);
//                            this.controllerUi.Select(false);
//                        }

//                        selected = false;
//                    }
//                }
//            }
//        } 
//    }
//}
