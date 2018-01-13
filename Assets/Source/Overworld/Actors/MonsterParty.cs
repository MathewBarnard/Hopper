using Assets.Source.Overworld.Actors.MonsterBehaviours;
using Assets.Source.Overworld.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Actors {
    public class MonsterParty : PartyActor {

        public BehaviourSet Behaviours;

        public static MonsterParty Create(Transform container, string partyFormation, HexTile tile) {
            GameObject obj = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Overworld/Actors/Monster")), tile.transform.position, Quaternion.identity, container.transform);
            MonsterParty party = obj.GetComponent<MonsterParty>();
            party.PartyFormation = partyFormation;
            tile.Inhabit(party);
            party.SetInhabitedNode(tile);
            return obj.GetComponent<MonsterParty>();
        }

        public new void ToggleVisiblity() {
            throw new NotImplementedException();
        }

        public new void ToggleVisiblity(bool setting) {
            spriteRenderer.enabled = setting;
        }
    }
}
