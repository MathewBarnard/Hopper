using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace Assets.Source.DataAccessLayer.Enemies {

    public class EnemyXml : IEnemyDAL {

        public Enemy LoadByFilename(string fileName) {

            // Set the path of the CharacterDataStore configuration
            string path = string.Format("{0}/Data/Enemies/enemy_{1}.xml", Application.dataPath, fileName);

            // Deserialize the XML file into an object.
            XmlSerializer serializer = new XmlSerializer(typeof(Enemy));
            StreamReader reader = new StreamReader(path);
            Enemy enemy = (Enemy)serializer.Deserialize(reader);
            reader.Close();

            return enemy;
        }
    }
}
