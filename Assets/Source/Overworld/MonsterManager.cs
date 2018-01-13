using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Map;
using Assets.Source.Overworld.Map.MapEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld {
    public class MonsterManager : MonoBehaviour {

        private List<MonsterParty> monstersInWorld;
        public List<MonsterParty> Monsters {
            get { return monstersInWorld; }
        }

        public void SetInitialSpawn(HexGrid grid, List<HexMapCsv> file) {

            monstersInWorld = new List<MonsterParty>();

            if (file != null) {
                List<HexMapCsv> inhabitedRows = file.Where(r => r.Inhabitant != string.Empty && r.Inhabitant != "main").ToList();

                foreach (HexMapCsv row in inhabitedRows) {
                    monstersInWorld.Add(MonsterParty.Create(this.gameObject.transform.parent, row.Inhabitant, grid.Tiles.Where(t => t.Coordinates.x == row.X && t.Coordinates.y == row.Z).First()));
                }
            }
        }
    }
}
