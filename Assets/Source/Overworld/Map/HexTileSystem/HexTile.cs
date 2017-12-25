using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {
    public class HexTile : MonoBehaviour {

        private SpriteRenderer spriteRenderer;

        private Vector2 normalisedPosition;
        private Vector3 hexCoordinates;

        private bool isDestination;
        public Actor inhabitingActor;
        public List<HexTile> connectedNodes;

        public void SetNormalisedPosition(float x, float y) {
            this.normalisedPosition = new Vector2(x, y);
        }

        public Vector3 SetCoordinates(int x, int y) {

            this.hexCoordinates = new Vector3(x, y, -y);
            return this.hexCoordinates;
        }

        public void Awake() {
            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        public void OnMouseOver() {
            if (IsAdjacentToPlayer() && !this.isDestination) {
                this.spriteRenderer.color = Color.green;
            }
            else {
                Debug.Log(this.hexCoordinates);
                this.spriteRenderer.color = Color.red;
            }
        }

        public void OnMouseExit() {
            if (!this.isDestination)
                this.spriteRenderer.color = Color.white;
        }

        public void OnMouseDown() {
            if (IsAdjacentToPlayer()) {
                OverworldEventManager.Instance().HexTileClicked(this);
                this.isDestination = true;
                this.spriteRenderer.color = Color.yellow;
            }
        }

        public void Deselect() {
            this.isDestination = false;
            this.spriteRenderer.color = Color.white;
        }

        public bool IsAdjacentToPlayer() {

            // Check all adjacent nodes for the player
            foreach (HexTile node in connectedNodes) {
                if (node.inhabitingActor != null && node.inhabitingActor is PlayerParty) {
                    return true;
                }
            }

            return false;
        }
    }
}
