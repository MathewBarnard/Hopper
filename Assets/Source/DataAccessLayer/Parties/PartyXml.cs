using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Source.DataAccessLayer.Parties {

    public class PartyXml : IPartyDAL {

        public Party LoadByFilename(string fileName) {

            // Set the path of the CharacterDataStore configuration
            string path = string.Format("{0}/Data/Parties/party_{1}.xml", Application.dataPath, fileName);

            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(Party));
            StreamReader reader = new StreamReader(path);
            Party party = (Party)serializer.Deserialize(reader);
            reader.Close();

            return party;
        }
    }
}
