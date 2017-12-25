//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Source.Overworld.Map {
//    public class NodeManager : MonoBehaviour {

//        private List<MapNode> allNodes;

//        public void Awake() {
//            List<GameObject> objects = GameObject.FindGameObjectsWithTag("MapNode").ToList();

//            List<MapNode> allNodes = new List<MapNode>();

//            foreach(GameObject obj in objects) {
//                allNodes.Add(obj.GetComponent<MapNode>());
//            }

//            this.allNodes = allNodes;
//        }

//        public void OnMouseDown() {
//            RaycastHit2D hit;

//            //Physics2D.Raycast(Input.GetMouseButtonDown()
//        }
//    }
//}
