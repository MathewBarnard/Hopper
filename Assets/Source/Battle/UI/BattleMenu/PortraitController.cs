using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.BattleMenu {
    public class PortraitController : MonoBehaviour {

        private GameObject currentPortrait;

        private void Awake() {
            BattleEventManager.Instance().onBeginActionSelection += SwitchPortrait;
            BattleEventManager.Instance().onTargetSelected += HidePortrait;
        }    

        public void SwitchPortrait(Combatant nextCombatant, Combatant previousCombatant) {

            if(this.currentPortrait != null)
                this.currentPortrait.SetActive(false);

            this.currentPortrait = this.transform.Find((nextCombatant as PlayerCombatant).Character.Name.ToLower()).gameObject;

            if(this.currentPortrait != null)
                this.currentPortrait.SetActive(true);
        }

        public void HidePortrait(List<Combatant> combatants)  {
            this.currentPortrait.SetActive(false);
        }
    }
}
