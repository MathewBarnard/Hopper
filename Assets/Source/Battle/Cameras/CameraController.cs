using Assets.Source.Battle.Cameras.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras {
    public class CameraController : MonoBehaviour {

        private CameraBehaviour currentBehaviour;

        public GameObject cameraAnchors;

        public void LookAtTarget(GameObject obj) {

            if(currentBehaviour != null) {
                Destroy(currentBehaviour);
            }

            LookAt lookAtBehaviour = this.gameObject.AddComponent<LookAt>();
            lookAtBehaviour.Target = obj;
            currentBehaviour = lookAtBehaviour;
        }

        public void LookAtTargetAdjacent(GameObject obj) {

            if (currentBehaviour != null) {
                Destroy(currentBehaviour);
            }

            LookAtAdjacent lookAtBehaviour = this.gameObject.AddComponent<LookAtAdjacent>();
            lookAtBehaviour.Target = obj;
            currentBehaviour = lookAtBehaviour;
        }

        public void MoveToAnchor(string anchorName) {

            if (currentBehaviour != null) {
                Destroy(currentBehaviour);
            }

            Transform obj = cameraAnchors.gameObject.transform.Find(anchorName);
            Anchored anchoredBehaviour = this.gameObject.AddComponent<Anchored>();
            anchoredBehaviour.anchor = obj.gameObject;
            currentBehaviour = anchoredBehaviour;
        }
    }
}
