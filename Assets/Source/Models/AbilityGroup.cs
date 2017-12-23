using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {
    
    [Serializable]
    public class AbilityGroup {

        [XmlArray(ElementName = "Abilities")]
        [XmlArrayItem("Ability")]
        public List<Ability> Abilities;
    }
}
