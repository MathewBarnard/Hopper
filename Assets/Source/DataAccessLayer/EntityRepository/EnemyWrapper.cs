using Assets.Source.DataAccessLayer.Enemies;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Source.DataAccessLayer.EntityRepository {
    public class EnemyWrapper : IEntityWrapper<Enemy> {

        private IEnemyDAL DAL;
        private List<Enemy> Enemies;

        public EnemyWrapper() {
            this.Enemies = new List<Enemy>();
            this.DAL = new EnemyXml();
        }

        public Enemy GetById(Guid id) {
            return null;
        }

        public Enemy GetByName(string name) {

            // Poll memory for this Enemy
            Enemy Enemy = Enemies.Where(c => c.Name == name).FirstOrDefault();

            // If they can't be found, load them and return.
            if (Enemy == null) {
                Enemy = (Enemy)this.DAL.LoadByFilename(name);
                this.Enemies.Add(Enemy);
                return Enemy;
            }
            else {
                return Enemy;
            }
        }

        public void Persist(Enemy Enemy) {

            if (!this.Enemies.Contains(Enemy))
                this.Enemies.Add(Enemy);
        }

        public void PersistList(List<Enemy> Enemys) {
            foreach (Enemy Enemy in Enemys) {
                this.Persist(Enemy);
            }
        }
    }
}
