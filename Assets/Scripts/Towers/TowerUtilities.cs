using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

namespace Towers {
    public class TowerUtilities
    {
        public static List<Enemy> GetEnemiesInRange(Transform tower, float range) {
            var colliders = Physics2D.OverlapCircleAll(tower.position, range);
            var enemies = new List<Enemy>();
            foreach (var item in colliders)
            {
                if (item.TryGetComponent<Enemy>(out Enemy enemy)) {
                    enemies.Add(enemy);
                }
            }
            return enemies;
        }
    }
}
