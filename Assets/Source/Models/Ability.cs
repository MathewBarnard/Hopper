using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class Ability {

        public Ability() {
            Name = string.Empty;
        }

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "TargetingType")]
        public Assets.Source.Battle.Spells.Abilities.TargetingType TargetingType;

        [XmlArray(ElementName = "AbilityLevels")]
        [XmlArrayItem("AbilityLevel")]
        public List<AbilityLevel> AbilityLevels;
    }
}
