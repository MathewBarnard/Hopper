using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class StatusEffect {

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;
    }
}
