using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI {
    public class AbilityTextPopup : MonoBehaviour {

        private Text guiText;
        private float lifespan;
        public float Lifespan {
            get { return lifespan; }
            set { lifespan = value; }
        }

        public static AbilityTextPopup Create(string text, Vector2 origin) {
            GameObject canvas = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/UI/AbilityTextPopup")));
            AbilityTextPopup abilityTextPopup = canvas.GetComponent<AbilityTextPopup>();

            GameObject obj = canvas.transform.GetChild(0).gameObject;
            Text guiText = obj.GetComponent<Text>();

            abilityTextPopup.guiText = guiText;
            abilityTextPopup.guiText.text = text;

            abilityTextPopup.Lifespan = 0.5f;

            canvas.transform.position = origin;

            return obj.GetComponent<AbilityTextPopup>();
        }

        public void Update() {

            this.transform.Translate(new Vector3(0.0f, 4.0f, 0.0f) * Time.deltaTime);

            this.lifespan -= Time.deltaTime;

            if(this.lifespan < 0.0f) {
                Destroy(this.gameObject);
            }
        }
    }
}
