using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class AbilityLevel {

        [XmlElement(ElementName = "Rank")]
        public int Rank;

        [XmlElement(ElementName = "PhysicalDamage")]
        public int PhysicalDamage;

        [XmlElement(ElementName = "TargetingType")]
        public TargetingType TargetingType;
    }
}
