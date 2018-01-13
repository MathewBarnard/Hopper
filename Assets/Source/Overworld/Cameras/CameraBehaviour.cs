using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Overworld.Cameras {
    /// <summary>
    /// An abstract class for a camera behaviour. We would develop an individual one of these for each different behaviour
    /// that we want the camera to perform, rather than containing it in a single controller.
    /// </summary>
    public abstract class CameraBehaviour : MonoBehaviour {

        // The camera that this behaviour is attached to
        protected Camera currentCamera;

        public virtual void Start() {

            // Get the camera that this behaviour is attached to.
            this.currentCamera = this.GetComponent<Camera>();
        }
    }

}
