using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {
    public class HexTile : MonoBehaviour {

        // The grid this tile belongs to
        public HexGrid GridParent;

        protected SpriteRenderer spriteRenderer;

        protected Vector2 normalisedPosition;
        public Vector3 hexCoordinates;
        public Vector3 Coordinates {
            get { return hexCoordinates; }
        }

        protected bool isDestination;
        public Actor inhabitingActor;
        public List<HexTile> connectedNodes;

        public void SetNormalisedPosition(float x, float y) {
            this.normalisedPosition = new Vector2(x, y);
        }

        public Vector3 SetCoordinates(int x, int y) {

            this.hexCoordinates = new Vector3(x, y, -y);
            return this.hexCoordinates;
        }

        public Vector3 SetCoordinates(Vector3 coordinates) {
            this.hexCoordinates = coordinates;
            return this.hexCoordinates;
        }

        public void Awake() {
            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        public void OnMouseEnter() {
            if (IsAdjacentToPlayer() && !this.isDestination) {
                this.spriteRenderer.color = Color.green;
            }
            else {
                //Debug.Log(this.hexCoordinates);
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

            List<HexTile> adjacentNodes = GridParent.GetAdjacentNodes(this);

            HexTile playerTile = adjacentNodes.Where(tile => tile.inhabitingActor != null).FirstOrDefault();

            if (playerTile == null)
                return false;
            else
                return true;
        }
    }
}
