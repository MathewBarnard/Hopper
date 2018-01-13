using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.MapEditor {

    public class HexMapCsv {

        private TileType tileType;
        public TileType TileType {
            get { return tileType; }
        }

        private int x;
        public int X {
            get { return x; }
        }

        private int z;
        public int Z {
            get { return z; }
        }

        private string inhabitant;
        public string Inhabitant {
            get { return inhabitant; }
        }

        public HexMapCsv(TileType tileType, int x, int z, string inhabitant = "") {
            this.tileType = tileType;
            this.x = x;
            this.z = z;
            this.inhabitant = inhabitant;
        }

        public HexMapCsv(string row) {
            string[] fields = row.Split(',');

            this.tileType = (TileType)Enum.Parse(typeof(TileType), fields[0]);
            this.x = Int32.Parse(fields[1]);
            this.z = Int32.Parse(fields[2]);

            if(fields.Length > 3)
                this.inhabitant = fields[3];
        }

        public override string ToString() {
            return String.Format("{0},{1},{2},{3}", new[] { tileType.ToString(), x.ToString(), z.ToString(), inhabitant });
        }
    }
}
