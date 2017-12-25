using Assets.Source.Overworld.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Map {
    public class HexTileEditor : MonoBehaviour {

        public string[] sprites = { "BaseTile", "BaseTileMountain" };
        public int index = 0;
        private SpriteRenderer spriteRenderer;
    }
}
