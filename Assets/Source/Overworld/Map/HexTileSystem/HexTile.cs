using Assets.Source.Overworld.Actors;
using System;
using System.Collections;
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

    public class HexTile : MonoBehaviour, IVisibility {

        public TileType tileType;
        public bool BlockLos;
        public bool IsObstacle;

        public static Vector3[] CubeDirections = { new Vector3(1, -1, 0), new Vector3(1, 0, -1), new Vector3(0, 1, -1),
                                                   new Vector3(-1, 1, 0), new Vector3(-1, 0, 1), new Vector3(0, -1, 1) };

        // Has the player seen this tile yet
        private bool discovered;
        public bool Discovered {
            get { return discovered; }
        }
        public void Discover() {
            discovered = true;
        }

        // The grid this tile belongs to
        public HexGrid GridParent;

        private List<HexTile> neighbours;
        public List<HexTile> Neighbours {
            get { return neighbours; }
        }
        public List<HexTile> TraversableNeighbours {
            get { return neighbours.Where(n => !n.IsObstacle).ToList(); }
        }


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

        private Vector2 axialCoordinates;
        public Vector2 AxialCoordinates {
            get { return AxialCoordinates; }
        }

        private Vector3 cubeCoordinates;
        public Vector3 CubeCoordinates {
            get { return cubeCoordinates; }
        }

        public Vector2 offsetCoordinates;
        public Vector2 OffsetCoordinates {
            get { return offsetCoordinates; }
        }

        protected bool isDestination;
        public Actor inhabitingActor;
        public List<HexTile> connectedNodes;

        public void Awake() {

            this.discovered = false;

            this.collider = this.GetComponent<Collider2D>();

            this.spriteRenderers = new List<SpriteRenderer>();

            if(this.gameObject.GetComponent<SpriteRenderer>() != null)
                this.spriteRenderers.Add(this.gameObject.GetComponent<SpriteRenderer>());

            if(this.gameObject.GetComponentsInChildren<SpriteRenderer>().ToArray().Length > 0)
                this.spriteRenderers.AddRange(this.gameObject.GetComponentsInChildren<SpriteRenderer>());
        }

        public void SetNeighbours(List<HexTile> neighbours) {
            this.neighbours = neighbours;
        }

        public Vector3 SetCoordinates(int x, int z) {

            this.coordinates = new Vector2(x, z);

            this.offsetCoordinates = new Vector2(x, z);

            this.cubeCoordinates = new Vector3(x, 0, z - (x / 2));
            this.cubeCoordinates = new Vector3(this.cubeCoordinates.x, -this.cubeCoordinates.x - this.cubeCoordinates.z, this.cubeCoordinates.z);

            this.axialCoordinates = new Vector2(this.cubeCoordinates.x, this.cubeCoordinates.y);

            return this.cubeCoordinates;
        }

        public static Vector2 CubeToOffset(Vector3 cubeCoords) {

            int column = (int)cubeCoords.x;
            int row = (int)cubeCoords.z + (int)cubeCoords.x - ((int)cubeCoords.x & 1) / 2;

            return new Vector2(column, row);
        }

        public Vector3 SetCoordinates(Vector3 coordinates) {
            this.cubeCoordinates = coordinates;
            return this.cubeCoordinates;
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
           // OverworldEventManager.Instance().HexTileClicked(this);
        }

        public void Inhabit(Actor actor) {
            this.inhabitingActor = actor;
            actor.SetInhabitedNode(this);
        }

        public void Uninhabit() {
            this.inhabitingActor.SetInhabitedNode(null);
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

        public void Colour(Color color) {
            foreach(SpriteRenderer renderer in spriteRenderers) {
                renderer.color = color;
            }
        }

        /// <summary>
        /// IVisiblity interface methods.
        /// </summary>
        #region IVisibility
        public void ToggleVisiblity() {
            if (this.spriteRenderers[0].enabled == false) {
                foreach (SpriteRenderer renderer in this.spriteRenderers) {
                    renderer.enabled = true;
                }
            }
            else {
                foreach (SpriteRenderer renderer in this.spriteRenderers) {
                    renderer.enabled = false;
                }
            }
        }

        public void ToggleFade() {
            foreach (SpriteRenderer renderer in this.spriteRenderers) {
                if (renderer.color.a != 128) {
                    Color color = renderer.color;
                    renderer.color = new Color(color.r, color.g, color.b, 128);
                }
                else {
                    Color color = renderer.color;
                    renderer.color = new Color(color.r, color.g, color.b, 255);
                }
            }
        }

        public void ToggleFade(float percentage) {
            foreach (SpriteRenderer renderer in this.spriteRenderers) {
                Color color = renderer.color;
                renderer.color = new Color(percentage, percentage, percentage, 1.0f);
            }
        }

        public void ToggleVisiblity(bool setting) {
            foreach (SpriteRenderer renderer in this.spriteRenderers) {
                renderer.enabled = setting;
            }
        }

        #endregion

        public static HexTile Create(HexGrid parent, TileType tileType, Vector2 worldPosition, Vector2 gridCoordinates) {

            Vector3 depthPosition = new Vector3(worldPosition.x, worldPosition.y, 10 + worldPosition.y);
            GameObject tile = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Overworld/Map/{0}", tileType.ToString())), depthPosition, Quaternion.identity, parent.gameObject.transform);
            tile.GetComponent<HexTile>().SetCoordinates((int)gridCoordinates.x, (int)gridCoordinates.y);
            tile.GetComponent<HexTile>().GridParent = parent;

            return tile.GetComponent<HexTile>();
        }
    }
}
