using Assets.Source.DataAccessLayer.Parties;
using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.DataAccessLayer.EntityRepository {
    public class PartyWrapper : IEntityWrapper<Party>{

        private IPartyDAL DAL;
        private List<Party> Parties;

        public PartyWrapper() {
            this.Parties = new List<Party>();
            this.DAL = new PartyXml();
        }

        public Party GetById(Guid id) {
            return null;
        }

        public Party GetByName(string name) {

            // Poll memory for this Party
            Party Party = Parties.Where(c => c.Name == name).FirstOrDefault();

            // If they can't be found, load them and return.
            if (Party == null) {
                Party = (Party)this.DAL.LoadByFilename(name);
                this.Parties.Add(Party);
                return Party;
            }
            else {
                return Party;
            }
        }

        public void Persist(Party Party) {

            if (!this.Parties.Contains(Party))
                this.Parties.Add(Party);
        }

        public void PersistList(List<Party> Partys) {
            foreach (Party Party in Partys) {
                this.Persist(Party);
            }
        }
    }
}
