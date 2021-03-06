﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class Ability : ICloneable {

        public Ability() {
            Name = string.Empty;
        }

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlElement(ElementName = "Description")]
        public string Description;

        [XmlElement(ElementName = "Cost")]
        public int Cost;

        [XmlElement(ElementName = "PhysicalDamageModifier")]
        public int PhysicalDamageModifier;

        [XmlElement(ElementName = "MagicalDamageModifier")]
        public int MagicalDamageModifier;

        [XmlElement(ElementName = "TargetingType")]
        public Assets.Source.Battle.Spells.Abilities.TargetingType TargetingType;

        [XmlArray(ElementName = "StatusEffects")]
        [XmlArrayItem("StatusEffect")]
        public List<StatusEffect> StatusEffects;

        [XmlElement(ElementName = "Metadata")]
        public Metadata Metadata;

        public object Clone() {
            var copy = (Ability)MemberwiseClone();

            copy.StatusEffects = StatusEffects.Select(c => (StatusEffect)c.Clone()).ToList();

            return copy; 
        }
    }
}
