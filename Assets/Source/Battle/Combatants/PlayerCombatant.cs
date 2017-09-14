using Assets.Source.Battle.Actions;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells;
using Assets.Source.Battle.Spells.Abilities;
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
            set {
                character = value;
                this.spellbook = new Spellbook(this, this.character.Abilities);
            }
        }

        public override void Awake() {
            base.Awake();
            character = new Character();
        }

        public override void Start() {
            base.Start();
        }

        public override Statistics GetStats() {
            return this.character.Stats;
        }
    }
}
