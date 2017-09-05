using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class Stat {

        public Stat() {
            Current = 0;
            Max = 0;
            Default = 0;
        }

        /// <summary>
        /// The current value of the stat.
        /// </summary>
        [XmlElement(ElementName = "Current")]
        public int Current;

        /// <summary>
        /// The characters max of this stat.
        /// </summary>
        [XmlElement(ElementName = "Max")]
        public int Max;

        /// <summary>
        /// The characters default health points. 
        /// </summary>
        [XmlElement(ElementName = "Default")]
        public int Default;
    }
}
