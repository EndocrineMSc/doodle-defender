using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers {
    [CreateAssetMenu(menuName="Towers/TowerCollection")]
    public class TowerCollection : ScriptableObject
    {
        [field: SerializeField] public List<TowerData> Towers {get; private set;}
    }
}
