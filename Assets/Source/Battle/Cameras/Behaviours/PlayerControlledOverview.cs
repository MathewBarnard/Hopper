﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.Cameras.Behaviours {
    public class PlayerControlledOverview : CameraBehaviour{

        private Vector3 previousPosition;

        private void Update() {


            if(UnityEngine.Input.GetMouseButtonDown(2)) {
                previousPosition = Input.mousePosition;
            }

            if(UnityEngine.Input.GetMouseButton(2)) {

                this.transform.Translate(new Vector3(-((Input.mousePosition.x - previousPosition.x) * 0.01f), 0.0f, 0.0f));

                previousPosition = Input.mousePosition;
            }
        }
    }
}