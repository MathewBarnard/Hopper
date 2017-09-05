using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras.Behaviours {
    public class LookAtAdjacent : CameraBehaviour {

        private const float HEIGHT = 4.0f;
        private const float DISTANCE = 6.0f;
        private const float SPEED = 2.0f;

        private GameObject target;
        public GameObject Target {
            get { return target; }
            set { target = value; }
        }

        void Update() {

            var lookPos = target.gameObject.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(lookPos);
            targetRotation.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, SPEED * Time.deltaTime);

            Vector3 targetPosition = target.transform.position;
            targetPosition.y = HEIGHT;
            targetPosition.z = targetPosition.z - DISTANCE;
            transform.position = Vector3.Lerp(transform.position, targetPosition, SPEED * Time.deltaTime);
        }
    }
}
