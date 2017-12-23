using Assets.Source.DataAccessLayer.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.DataAccessLayer {
    public class DataRepository {

        private static DataRepository instance;

        public CharacterWrapper Characters;
        public EnemyWrapper Enemies;
        public PartyWrapper Parties;

        public static DataRepository Instance() {

            if(instance == null) {
                instance = new DataRepository();
            }

            return instance;
        }

        /// <summary>
        /// Base constructor for the data repository. Instantiates all wrappers and loads all data on startup.
        /// </summary>
        public DataRepository() {

            this.LoadAllCharacters();
            this.LoadAllEnemies();
            this.LoadAllParties();
        }

        public void LoadAllCharacters() {

            // Instantiate our entity wrappers.
            this.Characters = new CharacterWrapper();
            this.Characters.GetByName("jack - Copy");
            //this.Characters.GetByName("test1");
            //this.Characters.GetByName("test2");
            //this.Characters.GetByName("test3");
        }

        public void LoadAllEnemies() {

            // Instantiate our entity wrappers.
            this.Enemies = new EnemyWrapper();
            //this.Enemies.GetByName("monster1");
        }

        public void LoadAllParties() {

            // Instantiate our entity wrappers.
            this.Parties = new PartyWrapper();
            this.Parties.GetByName("main");
            this.Parties.GetByName("test1");
        }
    }
}
