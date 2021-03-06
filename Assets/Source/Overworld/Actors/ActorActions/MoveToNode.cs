﻿using Assets.Source.Overworld.Map;
using Assets.Source.Engine.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors.ActorActions {
    public class MoveToNode : ActorAction {

        private Actor actor;
        private HexTile origin;
        private HexTile destination;

        public static MoveToNode CreateComponent(GameObject objectToAttachTo, HexTile origin, HexTile destination) {
            MoveToNode action = objectToAttachTo.AddComponent<MoveToNode>();
            action.origin = origin;
            action.destination = destination;
            action.actor = objectToAttachTo.GetComponent<Actor>();
        
            return action;
        }

        public static MoveToNode Create(Actor actor, HexTile destination) {
            MoveToNode action = actor.gameObject.AddComponent<MoveToNode>();
            action.destination = destination;
            action.actor = actor;

            return action;
        }

        private void Update() {
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.destination.transform.position, 2.0f * Time.deltaTime);

            if (this.transform.position == this.destination.transform.position) {

                //Actor traveller = origin.inhabitingActor;

                // The actor stores the currently inhabited tile.
                //traveller.InhabitedNode = this.destination;

                actor.InhabitedNode.Uninhabit();
                this.destination.Inhabit(actor);

                //// Move player from origin tile to destination tile
                //this.destination.Inhabit(actor);

                this.complete = true;
            }
        }

        public void OnDestroy() {
            OverworldEventManager.Instance().ArrivedAtTile(destination);
        }
    }
}
