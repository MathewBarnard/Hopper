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
        BaseTileWall,
        Empty
    };

    public class HexTile : MonoBehaviour {

        public TileType tileType;
        public bool BlockLos;

        // The grid this tile belongs to
        public HexGrid GridParent;

        // UnityComponents
        protected List<SpriteRenderer> spriteRenderers;
        protected Collider2D collider;
        public Collider2D Collider {
            get { return collider; }
        }

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

        public void Awake() {
            this.collider = this.GetComponent<Collider2D>();

            this.spriteRenderers = new List<SpriteRenderer>();

            if(this.gameObject.GetComponent<SpriteRenderer>() != null)
                this.spriteRenderers.Add(this.gameObject.GetComponent<SpriteRenderer>());

            if(this.gameObject.GetComponentsInChildren<SpriteRenderer>().ToArray().Length > 0)
                this.spriteRenderers.AddRange(this.gameObject.GetComponentsInChildren<SpriteRenderer>());
        }

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

        public void OnMouseEnter() {
            if (IsAdjacentToPlayer() && !this.isDestination) {
                OverworldEventManager.Instance().HexTileFocused(this);
            }
        }

        public void OnMouseExit() {
            if (!this.isDestination) {
                OverworldEventManager.Instance().HexTileUnfocused(this);
            }
        }

        public void OnMouseDown() {
            if (IsAdjacentToPlayer()) {
                OverworldEventManager.Instance().HexTileClicked(this);
            }
        }

        public void ToggleVisiblity() {
            if (this.spriteRenderers[0].enabled == false) {
                foreach(SpriteRenderer renderer in this.spriteRenderers) {
                    renderer.enabled = true;
                }
            }
            else {
                foreach (SpriteRenderer renderer in this.spriteRenderers) {
                    renderer.enabled = false;
                }
            }
        }

        public void ToggleVisiblity(bool setting) {
            foreach (SpriteRenderer renderer in this.spriteRenderers) {
                renderer.enabled = setting;
            }
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

            Vector3 depthPosition = new Vector3(worldPosition.x, worldPosition.y, 10 + gridCoordinates.y);
            GameObject tile = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Overworld/{0}", tileType.ToString())), depthPosition, Quaternion.identity, parent.gameObject.transform);
            tile.GetComponent<HexTile>().SetCoordinates((int)gridCoordinates.x, (int)gridCoordinates.y);
            tile.GetComponent<HexTile>().GridParent = parent;
            return tile.GetComponent<HexTile>();
        }
    }
}
