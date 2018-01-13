using Assets.Source.Overworld.Actors;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Cameras {
    public class FollowActor : CameraBehaviour {

        private bool active;
        public Actor target;

        public void Awake() {
            OverworldEventManager.Instance().onArrivedAtTile += MoveCameraToPlayer;
            active = false;
        }

        public void Update() {

            if (active) {
                float distance = Vector2.Distance(this.transform.position, target.transform.position);

                this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, (distance * 2.0f) * Time.deltaTime);
            }
        }

        public void MoveCameraToPlayer(HexTile tile) {
            active = true;
        }
    }
}
