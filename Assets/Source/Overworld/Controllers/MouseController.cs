using Assets.Source.Engine.Actions;
using Assets.Source.Overworld.Actors.ActorActions;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Controllers {
    public class MouseController : MonoBehaviour {

        private Actors.Actor actor;

        public void Awake() {
            this.actor = this.GetComponent<Actors.Actor>();

            //OverworldEventManager.Instance().onAdvanceTurn += Disable;
            //OverworldEventManager.Instance().onResolveTurn += Enable;
        }

        public void Enable() {
            this.enabled = true;
        }

        public void Disable() {
            this.enabled = false; ;
        }

        public void Update() {

            if(Input.GetMouseButtonDown(1)) {
                if(actor.actionQueue.CurrentAction == null) {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("Traversable"));

                    if (hit.collider != null) {
                        HexTile tile = hit.collider.gameObject.GetComponent<HexTile>();
                        OverworldEventManager.Instance().HexTileClicked(tile);
                    }
                }
            }
        }

        public void MoveToTile(HexTile tile) {

            if (tile == null) {
                Debug.Log("A collider was detected that wasn't a tile! Is there a configuration issue?");
                return;
            }

            Debug.DrawLine(actor.transform.position, tile.transform.position);
            actor.InhabitedNode.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            var hit = Physics2D.Linecast(actor.transform.position, tile.transform.position, 1 << LayerMask.NameToLayer("Traversable"));
            actor.InhabitedNode.gameObject.layer = LayerMask.NameToLayer("Traversable");

            if (hit.collider != null) {
                HexTile nearestTile = hit.collider.gameObject.GetComponent<HexTile>();

                if (tile != null) {
                    this.actor.GetComponent<Engine.Actions.ActionQueue>().AddToFront(MoveToNode.CreateComponent(this.actor.gameObject, this.actor.InhabitedNode, nearestTile));
                }
            }
        }
    }
}
