using Assets.Source.Battle.Combatants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Source.Battle.UI.Callbacks {

    public delegate void StringCallback(string parameter);

    public delegate void CombatantWithString(Combatant combatant, string parameter);

    public delegate void CombatantWithGameObject(Combatant combatant, GameObject obj);

    public delegate void GameObjectCallback(GameObject parameter);
}
