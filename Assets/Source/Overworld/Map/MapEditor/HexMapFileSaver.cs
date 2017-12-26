using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.MapEditor {

    public class HexMapFileSaver {

        /// <summary>
        /// Saves a hex grid file from a list of existing tiles.
        /// </summary>
        /// <param name="hexTiles"></param>
        public static List<HexMapCsv> SaveFile(List<HexTile> hexTiles) {

            List<HexMapCsv> rows = new List<HexMapCsv>();

            hexTiles = hexTiles.OrderBy(tile => tile.Coordinates.x).ThenBy(tile => tile.Coordinates.y).ToList();

            foreach (HexTile tile in hexTiles) {
                rows.Add(new HexMapCsv(tile.tileType, (int)tile.Coordinates.x, (int)tile.Coordinates.y));
            }

            // Convert to string
            List<string> rowsAsString = new List<string>();

            foreach (HexMapCsv row in rows) {
                rowsAsString.Add(row.ToString());
            }

            string path = string.Format("{0}/Data/MapEditor/map.csv", Application.dataPath);

            System.IO.File.WriteAllLines(@path, rowsAsString.ToArray());

            return rows;
        }

        public static List<HexMapCsv> ReadFile(string filename) {

            string path = string.Format("{0}/Data/MapEditor/map.csv", Application.dataPath);

            string[] rows = System.IO.File.ReadAllLines(path);

            List<HexMapCsv> models = new List<HexMapCsv>();

            foreach(string row in rows) {
                models.Add(new HexMapCsv(row));
            }

            return models;
        }
    }
}
