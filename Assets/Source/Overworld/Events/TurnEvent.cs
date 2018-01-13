using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld.Events {
    public abstract class TurnEvent {

        public abstract void Setup();
        public abstract void Go();
    }
}
