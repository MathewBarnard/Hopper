//using Assets.Source.Overworld.Actors;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Source.Overworld.Map {
//    public class MapNode : MonoBehaviour {

//        private SpriteRenderer spriteRenderer;

//        private bool isDestination;
//        public Actor inhabitingActor;
//        public List<MapNode> connectedNodes;

//        public void Awake() {
//            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
//        }

//        public void OnMouseOver() {
//            if(IsAdjacentToPlayer() && !this.isDestination) {
//                this.spriteRenderer.color = Color.green;
//            }
//        }

//        public void OnMouseExit() {
//            if(!this.isDestination)
//                this.spriteRenderer.color = Color.white;
//        }

//        public void OnMouseDown() {
//            if (IsAdjacentToPlayer()) {
//                OverworldEventManager.Instance().MapNodeClicked(this);
//                this.isDestination = true;
//                this.spriteRenderer.color = Color.yellow;
//            }
//        }

//        public void Deselect() {
//            this.isDestination = false;
//            this.spriteRenderer.color = Color.white;
//        }

//        public bool IsAdjacentToPlayer() {

//            // Check all adjacent nodes for the player
//            foreach(MapNode node in connectedNodes) {
//                if(node.inhabitingActor != null && node.inhabitingActor is PlayerParty) {
//                    return true;
//                }
//            }

//            return false;
//        }
//    }
//}
