using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map.HexTileSystem {
    public class Pathfinder {

        public static Queue<HexTile> BreadthFirstSearch(HexTile startTile, HexTile destinationTile) {

            Queue<HexTile> frontier = new Queue<HexTile>();
            frontier.Enqueue(startTile);

            Hashtable cameFrom = new Hashtable();
            cameFrom.Add(startTile, null);

            HexTile current = null;

            while(frontier.Count != 0) {
                current = frontier.Dequeue();

                foreach(HexTile neighbourTile in current.TraversableNeighbours) {
                    if(!cameFrom.ContainsKey(neighbourTile)) {
                        frontier.Enqueue(neighbourTile);
                        cameFrom.Add(neighbourTile, current);
                    }
                }
            }

            current = destinationTile;

            Queue<HexTile> path = new Queue<HexTile>();
            
            while(current != startTile) {
                path.Enqueue(current);
                current = (HexTile)cameFrom[current];
            }

            return new Queue<HexTile>(path.Reverse());
        }
    }
}
