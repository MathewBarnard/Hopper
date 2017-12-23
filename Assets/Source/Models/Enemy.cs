using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable, XmlRoot(ElementName = "Enemy")]
    public class Enemy {

        public Enemy() {
            Name = string.Empty;
        }

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "Stats")]
        public Statistics Stats;

        [XmlArray(ElementName = "Abilities")]
        [XmlArrayItem("AbilityGroup")]
        public List<AbilityGroup> Abilities;
    }
}
