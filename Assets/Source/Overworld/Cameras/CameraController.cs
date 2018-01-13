using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Cameras {
    /// <summary>
    /// This poor wee guy is a bit empty now. The actual behaviour has been encapsulated into its own script. The camera controller will act
    /// as the master for the camera, controlling how/when we switch between different states.
    /// </summary>
    public class CameraController : MonoBehaviour {

        // The camera that this script is attached to.
        private Camera currentCamera;

        // The current behaviour of the camera: ie following player, following target, fixed position etc.
        public CameraBehaviour currentBehaviour;

        void Start() {
            // Get the camera that this behaviour is attached to.
            this.currentCamera = this.GetComponent<Camera>();
        }
    }

}
