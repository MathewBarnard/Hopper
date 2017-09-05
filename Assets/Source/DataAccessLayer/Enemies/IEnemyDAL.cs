﻿using Assets.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.DataAccessLayer.Enemies {
    public interface IEnemyDAL {

        Enemy LoadByFilename(string fileName);
    }
}
