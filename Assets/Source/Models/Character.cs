using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable, XmlRoot(ElementName = "Character")]
    public class Character {

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "Stats")]
        public Statistics Stats;

        [XmlArray(ElementName = "Abilities")]
        [XmlArrayItem("Ability")]
        public List<Ability> Abilities;
    }
}
