using Assets.Source.Engine.Actions;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors {
    public abstract class Actor : MonoBehaviour, IVisibility {

        protected SpriteRenderer spriteRenderer;

        public ActionQueue actionQueue;

        private HexTile destination;
        private HexTile inhabitedNode;
        public HexTile InhabitedNode {
            get { return inhabitedNode; }
        }

        public void SetInhabitedNode(HexTile tile) {
            inhabitedNode = tile;
        }

        public void Awake() {
            this.spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        }

        public void ToggleFade() {
            if (this.spriteRenderer.color.a != 128) {
                Color color = this.spriteRenderer.color;
                this.spriteRenderer.color = new Color(color.r, color.g, color.b, 128);
            }
            else {
                Color color = this.spriteRenderer.color;
                this.spriteRenderer.color = new Color(color.r, color.g, color.b, 256);
            }
        }

        public void ToggleFade(float percentage) {
            Color color = this.spriteRenderer.color;
            this.spriteRenderer.color = new Color(color.r, color.g, color.b, percentage);
        }

        public void ToggleVisiblity() {
            throw new NotImplementedException();
        }

        public new void ToggleVisiblity(bool setting) {
            spriteRenderer.enabled = setting;
        }
    }
}
