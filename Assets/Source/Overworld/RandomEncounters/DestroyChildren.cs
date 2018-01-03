using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.RandomEncounters {
    public class DestroyChildren : MonoBehaviour {

        public void Awake() {

            foreach(Transform child in this.transform) {
                Destroy(child.gameObject);
            }
        }
    }
}
