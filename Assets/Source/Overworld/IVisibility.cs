using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld {
    public interface IVisibility {

        void ToggleVisiblity();

        void ToggleVisiblity(bool setting);

        void ToggleFade();

        void ToggleFade(float percentage);
    }
}
