using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Development {
    public class HighlightedCircle : MonoBehaviour {

        public Combatant combatant;

        private bool animating;

        private float lowerScale;
        private float upperScale;
        private float increment;

        public void Highlight(bool flag) {
            this.gameObject.SetActive(flag);
        }

        public void Select(bool flag) {
            animating = flag;
        }

        void Awake() {

            BattleEventManager.Instance().onBeginTurn += Enable;
            BattleEventManager.Instance().onTargetChanged += EnableIfTargeted;
            BattleEventManager.Instance().onTargetSelected += Disable;

            this.lowerScale = this.transform.localScale.x;
            this.upperScale = this.lowerScale + 0.05f;
            this.increment = 1.0f;

            this.gameObject.SetActive(false);
        }

        void Update() {

            if(animating) {
                
                if(this.transform.localScale.x >= upperScale || this.transform.localScale.x <= lowerScale) {
                    increment = increment * -1;
                }

                this.transform.localScale.Set(this.transform.localScale.x + (increment * Time.deltaTime), this.transform.localScale.y + (increment * Time.deltaTime), this.transform.localScale.z + (increment * Time.deltaTime));
            }
        }

        public void Enable(Combatant combatant) {

            if(this.combatant == combatant) {
                this.gameObject.SetActive(true);
            }
        }

        public void Disable(List<Combatant> targets) {

            this.gameObject.SetActive(false);
        }

        public void EnableIfTargeted(Combatant oldTarget, Combatant newTarget) {

            if (oldTarget == this.combatant) {
                this.gameObject.SetActive(false);
            }

            if (newTarget == this.combatant) {
                this.gameObject.SetActive(true);
            }
        }
    }
}
