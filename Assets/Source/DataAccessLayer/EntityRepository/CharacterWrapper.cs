using Assets.Source.DataAccessLayer.Characters;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.DataAccessLayer.EntityRepository {
    public class CharacterWrapper : IEntityWrapper<Character> {

        private ICharacterDAL DAL;
        private List<Character> Characters;

        public CharacterWrapper() {
            this.Characters = new List<Character>();
            this.DAL = new CharacterXml();
        }

        public Character GetById(Guid id) {
            return null;
        }

        public Character GetByName(string name) {

            // Poll memory for this Character
            Character Character = Characters.Where(c => c.Name == name).FirstOrDefault();

            // If they can't be found, load them and return.
            if (Character == null) {
                Character = (Character)this.DAL.LoadByFilename(name);
                this.Characters.Add(Character);
                return Character;
            }
            else {
                return Character;
            }
        }

        public void Persist(Character Character) {

            if (!this.Characters.Contains(Character))
                this.Characters.Add(Character);
        }

        public void PersistList(List<Character> Characters) {
            foreach (Character Character in Characters) {
                this.Persist(Character);
            }
        }
    }
}
