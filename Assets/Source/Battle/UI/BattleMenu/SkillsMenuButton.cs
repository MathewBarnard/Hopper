using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI {
    public class SkillsMenuButton : MonoBehaviour  {

        private Text text;
        private Button button;

        public static SkillsMenuButton Create(BattleMenu parentMenu, string abilityName, int position) {

            GameObject skillsMenuButton = Instantiate((GameObject)Resources.Load(string.Format("Prefabs/Battle/UI/SkillsMenuButton")), new Vector3(0.0f, -50.0f * position, 0.0f), Quaternion.identity);
            skillsMenuButton.transform.SetParent(parentMenu.skillsMenu.transform.Find("SkillsContainer").transform, false);
            SkillsMenuButton menuButtonScript = skillsMenuButton.GetComponent<SkillsMenuButton>();
            menuButtonScript.text = skillsMenuButton.GetComponentInChildren<Text>();
            menuButtonScript.text.text = abilityName;
            menuButtonScript.button = skillsMenuButton.GetComponentInChildren<Button>();
            menuButtonScript.button.onClick.AddListener(delegate { parentMenu.SkillSelected(abilityName); } );
            return menuButtonScript;
        }
    }
}
