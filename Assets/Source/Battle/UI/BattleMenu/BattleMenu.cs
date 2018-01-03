using Assets.Source.Battle.Combatants;
using Assets.Source.Battle.Events;
using Assets.Source.Battle.Spells.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.Battle.UI {

    public class BattleMenu : MonoBehaviour {

        private Combatant actingCombatant;

        // Other UI elements that this menu controls.
        public GameObject skillsMenu;

        private void Awake() {
            BattleEventManager.Instance().onTargetingCancelled += Enable;
        }

        public void SetActingCombatant(Combatant combatant) {
            this.actingCombatant = combatant;

            this.PopulateSkillsMenu(actingCombatant.Spellbook.Skills);
        }

        public void AttackSelected() {
            Ability ability = actingCombatant.Spellbook.All.Where(abl => abl.Name().ToLower() == "attack").FirstOrDefault();
            BattleEventManager.Instance().ActionSelected(actingCombatant, ability);
            this.gameObject.SetActive(false);
        }

        public void OpenSkillsSelected() {
            this.gameObject.SetActive(false);
            this.skillsMenu.SetActive(true);
        }

        public void CloseSkills() {
            this.gameObject.SetActive(true);
            this.skillsMenu.SetActive(false);
        }

        public void CloseAll() {
            this.gameObject.SetActive(false);
            this.skillsMenu.SetActive(false);
        }

        public void OpenItemsSelected() {
            this.gameObject.SetActive(false);
        }

        private void PopulateSkillsMenu(List<Ability> abilities) {

            int menuPosition = 1;

            foreach(Ability ability in abilities) {

                SkillsMenuButton.Create(this, ability.Name(), menuPosition);
                menuPosition += 1;
            }
        }

        public void SkillSelected(string abilityName) {
            Ability ability = actingCombatant.Spellbook.All.Where(abl => abl.Name() == abilityName).FirstOrDefault();
            BattleEventManager.Instance().ActionSelected(actingCombatant, ability);
            this.CloseAll();
        }

        private void HideSkillsMenu() {

        }

        public void Enable() {
            this.gameObject.SetActive(true);
        }
    }
}
