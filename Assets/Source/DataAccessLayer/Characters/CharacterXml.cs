using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Source.DataAccessLayer.Characters {
    public class CharacterXml : ICharacterDAL {

        public Character LoadByFilename(string fileName) {

            // Set the path of the CharacterDataStore configuration
            string path = string.Format("{0}/Data/Characters/character_{1}.xml", Application.dataPath, fileName);

            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            StreamReader reader = new StreamReader(path);
            Character character = (Character)serializer.Deserialize(reader);
            reader.Close();

            return character;
        }
    }
}
