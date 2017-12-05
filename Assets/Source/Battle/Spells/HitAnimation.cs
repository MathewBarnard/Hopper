using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Spells {
    public class HitAnimation : MonoBehaviour{

        private Animator animator;

        void Awake() {
            animator = this.GetComponent<Animator>();
        }

        private void Start() {

        }
    }
}
