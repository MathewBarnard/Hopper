using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras.Behaviours {
    public class LookAt : CameraBehaviour {

        private GameObject target;
        public GameObject Target {
            get { return target; }
            set { target = value; }
        }

        void Update() {

            Quaternion targetRotation = Quaternion.LookRotation(target.gameObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1.0f * Time.deltaTime);
        }
    }
}
