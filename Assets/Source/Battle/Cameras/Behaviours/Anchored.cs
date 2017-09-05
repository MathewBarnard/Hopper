using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras.Behaviours {
    public class Anchored : CameraBehaviour {

        private const float Speed = 3.0f;

        public GameObject anchor;

        void Update() {

            Vector3 relativePosition = anchor.transform.position - this.gameObject.transform.position;
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, anchor.transform.position, Speed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(transform.rotation, anchor.transform.rotation, Speed * Time.deltaTime);
        }
    }
}
