using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable, XmlRoot(ElementName = "Party")]
    public class Party : ICloneable {

        public Party() {
            Id = Guid.Empty;
            Name = string.Empty;
            Members = null;
        }

        [XmlElement(ElementName = "Id")]
        public Guid Id;

        [XmlElement(ElementName = "Name")]
        public string Name;

        [XmlArray(ElementName = "Members")]
        [XmlArrayItem("Member")]
        public List<string> Members;

        public object Clone() {

            var copy = (Party)this.MemberwiseClone();

            copy.Members = Members.Select(c => (string)c.Clone()).ToList();

            return copy;
        }
    }
}
