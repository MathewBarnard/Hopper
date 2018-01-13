using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Assets.Source.Models {

    [Serializable]
    public class Statistics : ICloneable {

        public Statistics() {
            Health = new Models.Stat();
            Attack = new Models.Stat();
            Defense = new Models.Stat();
            Speed = new Models.Stat();
        }

        [XmlElement(ElementName = "Health")]
        public Stat Health;

        [XmlElement(ElementName = "Attack")]
        public Stat Attack;

        [XmlElement(ElementName = "Defense")]
        public Stat Defense;

        [XmlElement(ElementName = "Speed")]
        public Stat Speed;

        public object Clone() {
            var copy = (Statistics)MemberwiseClone();

            copy.Health = (Stat)Health.Clone();
            copy.Attack = (Stat)Attack.Clone();
            copy.Defense = (Stat)Defense.Clone();
            copy.Speed = (Stat)Speed.Clone();

            return copy;
        }
    }
}
