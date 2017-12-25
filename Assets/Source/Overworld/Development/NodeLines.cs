//using Assets.Source.Overworld.Map;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Source.Overworld.Development {
//    public class NodeLines : MonoBehaviour {

//        public GameObject nodeContainer;
//        private List<MapNode> mapNodes;

//        public void Update() {

//            this.mapNodes = nodeContainer.GetComponentsInChildren<MapNode>().ToList();

//            foreach(MapNode node in mapNodes) {

//                foreach (MapNode connectedNode in node.connectedNodes) {
//                    Debug.DrawLine(node.transform.position, connectedNode.transform.position, Color.white);
//                }
//            }
//        }
//    }
//}
