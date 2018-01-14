using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld.Events {
    public abstract class TurnEvent {

        private bool complete;
        public bool Complete {
            get { return complete; }
        }

        public abstract bool IsComplete();
        public abstract void Go();
    }
}
