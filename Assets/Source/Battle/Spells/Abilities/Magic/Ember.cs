﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Battle.Spells.Abilities.Magic {
    public class Ember : Ability {

        public Ember() {

        }

        public Ember(Models.Ability abilityModel) {

        }

        public override Type[] GetActions() {

            Type[] actions = new Type[2];

            actions[0] = typeof(Actions.Abilities.Casting);
            actions[1] = typeof(Actions.Attacks.Ember);

            return actions;
        }

        public override string Name() {
            return "ember";
        }

        public override AbilityType AbilityType() {
            return Spells.AbilityType.ember;
        }

        public override void Process() {
            throw new NotImplementedException();
        }

        public override void AttachScripts() {
            throw new NotImplementedException();
        }

        public override void ApplyMomentum(int momentum) {
            throw new NotImplementedException();
        }
    }
}
