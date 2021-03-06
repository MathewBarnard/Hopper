﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Source.Overworld.Map;

namespace Assets.Source.Overworld.RandomEncounters {
    public class TimedEncounterGenerator : RandomEncounterGenerator {

        private float time;
        private float encounterTriggerTime;

        public TimedEncounterGenerator(float encounterTriggerTime) {
            this.encounterTriggerTime = encounterTriggerTime;
        }

        public override bool CheckForEncounter() {
            time += UnityEngine.Time.deltaTime;

            if (time > encounterTriggerTime) {
                time = 0.0f;
                return true;
            }
            else
                return false;
        }

        public override bool CheckForEncounter(HexTile tile) {
            throw new NotImplementedException();
        }
    }
}
