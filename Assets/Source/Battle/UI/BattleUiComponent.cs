using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI {
    public abstract class BattleUiComponent : MonoBehaviour {

        protected List<GameObject> artifacts;

        private void OnDestroy() {
            foreach (GameObject uiArtifact in this.artifacts) {
                Destroy(uiArtifact);
            }
        }
    }
}
