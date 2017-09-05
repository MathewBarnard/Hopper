using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.DataAccessLayer.Characters {
    public interface ICharacterDAL {

        Character LoadByFilename(string fileName);
    }
}
