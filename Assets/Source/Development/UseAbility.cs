using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Development {
    public class UseAbility : MonoBehaviour {

        public Combatant target;

        private void Update() {

            if(target != null) {

                this.gameObject.GetComponent<Combatant>().Target = target;
                AttackMelee attack = new AttackMelee();
                ActionAttacher.AttachScriptsForAbility(this.gameObject.GetComponent<Combatant>(), attack);
                target = null;
            }
        }
    }
}
