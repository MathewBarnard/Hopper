using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.Overworld.Actors.MonsterBehaviours.Triggers {
    public class PlayerInRange : BehaviourTrigger {

        private Actor actor;
        public int Range;

        public void Awake() {
            this.actor = GetComponent<Actor>();
        }

        public override bool IsTriggered() {
            // If player is within the enemies range, the enemy should start moving towards them.
            List<HexTile> surroundingTiles = actor.InhabitedNode.GridParent.GetTilesInRange(actor.InhabitedNode, Range);

            HexTile playerTile = null;

            foreach (HexTile tileInRange in surroundingTiles) {
                if (tileInRange.inhabitingActor != null && tileInRange.inhabitingActor is PlayerParty) {
                    playerTile = tileInRange;
                }
            }

            if (playerTile != null) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
