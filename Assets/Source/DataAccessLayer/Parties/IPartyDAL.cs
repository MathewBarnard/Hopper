using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.DataAccessLayer.Parties {
    public interface IPartyDAL {

        Party LoadByFilename(string fileName);
    }
}
