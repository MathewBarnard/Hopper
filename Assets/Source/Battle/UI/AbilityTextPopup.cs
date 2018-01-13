using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI {
    public class AbilityTextPopup : MonoBehaviour {

        private static float totalLifespan = 1.0f;

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

            abilityTextPopup.Lifespan = totalLifespan;

            canvas.transform.position = origin;

            return obj.GetComponent<AbilityTextPopup>();
        }

        public static AbilityTextPopup Create(string text, Vector2 origin, Color color) {
            GameObject canvas = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/UI/AbilityTextPopup")));
            AbilityTextPopup abilityTextPopup = canvas.GetComponent<AbilityTextPopup>();

            GameObject obj = canvas.transform.GetChild(0).gameObject;
            Text guiText = obj.GetComponent<Text>();

            abilityTextPopup.guiText = guiText;
            abilityTextPopup.guiText.text = text;
            abilityTextPopup.guiText.color = color;

            abilityTextPopup.Lifespan = totalLifespan;

            canvas.transform.position = origin;

            return obj.GetComponent<AbilityTextPopup>();
        }

        public void Update() {

            if(this.lifespan > totalLifespan / 1.2f)
                this.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f) * Time.deltaTime);

            this.lifespan -= Time.deltaTime;

            if(this.lifespan < 0.0f) {
                Destroy(this.gameObject);
            }
        }
    }
}
