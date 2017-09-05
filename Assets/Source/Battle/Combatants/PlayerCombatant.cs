using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Combatants {
    public class PlayerCombatant : Combatant {

        private Character character;
        public Character Character {
            get { return character; }
            set { character = value; }
        }

        public override void Awake() {
            base.Awake();
            character = new Character();
        }
    }
}
