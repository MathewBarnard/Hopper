using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class Metadata {

        [XmlElement(ElementName = "SpellAnimation")]
        public string SpellAnimation;
    }
}
