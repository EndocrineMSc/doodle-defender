using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Towers {
    	[CreateAssetMenu(menuName="Tower Data")]
    	public class TowerData : ScriptableObject
    	{
    	    [field: SerializeField] public string Name {get; private set;}
    	    [field: SerializeField, TextArea] public string Description {get; private set;}
    	
    	    [field: SerializeField] public int AttackDamage {get; private set;} 
    	    [field: SerializeField] public int AttackSpeed {get; private set;} 
    	    [field: SerializeField] public float AttackRange {get; private set;}
    	
            [field: SerializeField] public Sprite TowerSprite {get; private set;}
    	    [field: SerializeField] public TowerAttack AttackPrefab {get; private set;} 
    	}
}

