using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {

    public enum TileType 
    {
        BaseTile,
        BaseTileMountain,
        BaseTileTown
    };

    public class HexTile : MonoBehaviour {

        public TileType tileType;

        // The grid this tile belongs to
        public HexGrid GridParent;

        protected SpriteRenderer spriteRenderer;

        protected Vector2 coordinates;
        public Vector2 Coordinates {
            get { return coordinates; }
        }
        public Vector3 axialCoordinates;
        public Vector3 AxialCoordinates {
            get { return axialCoordinates; }
        }

        protected bool isDestination;
        public Actor inhabitingActor;
        public List<HexTile> connectedNodes;

        public Vector3 SetCoordinates(int x, int z) {

            this.coordinates = new Vector2(x, z);

            this.axialCoordinates = new Vector3(x - (z / 2), 0, z);
            this.axialCoordinates = new Vector3(this.axialCoordinates.x, -this.axialCoordinates.x - this.axialCoordinates.z, this.axialCoordinates.z);
            return this.axialCoordinates;
        }

        public Vector3 SetCoordinates(Vector3 coordinates) {
            this.axialCoordinates = coordinates;
            return this.axialCoordinates;
        }

        public void Awake() {
            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        public void OnMouseEnter() {
            if (IsAdjacentToPlayer() && !this.isDestination) {
                this.spriteRenderer.color = Color.green;
            }
            else {
                //Debug.Log(this.axialCoordinates);
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
            }
        }

        public void Deselect() {
            this.isDestination = false;
            this.spriteRenderer.color = Color.white;
        }

        public void Inhabit(Actor actor) {
            this.inhabitingActor = actor;
        }

        public void Uninhabit() {
            this.inhabitingActor = null;
        }

        public bool IsAdjacentToPlayer() {

            List<HexTile> adjacentNodes = GridParent.GetAdjacentNodes(this);

            HexTile playerTile = adjacentNodes.Where(tile => tile.inhabitingActor != null).FirstOrDefault();

            if (playerTile == null)
                return false;
            else
                return true;
        }

        public static HexTile Create(HexGrid parent, TileType tileType, Vector2 worldPosition, Vector2 gridCoordinates) {

            GameObject tile = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Overworld/{0}", tileType.ToString())), worldPosition, Quaternion.identity, parent.gameObject.transform);
            tile.GetComponent<HexTile>().SetCoordinates((int)gridCoordinates.x, (int)gridCoordinates.y);
            tile.GetComponent<HexTile>().GridParent = parent;
            return tile.GetComponent<HexTile>();
        }
    }
}
