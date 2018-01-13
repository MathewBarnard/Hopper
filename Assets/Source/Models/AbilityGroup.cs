using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {
    
    [Serializable]
    public class AbilityGroup : ICloneable{

        [XmlArray(ElementName = "Abilities")]
        [XmlArrayItem("Ability")]
        public List<Ability> Abilities;

        public object Clone() {

            var copy = (AbilityGroup)MemberwiseClone();

            copy.Abilities = Abilities.Select(c => (Ability)c.Clone()).ToList();

            return copy;
        }
    }
}
