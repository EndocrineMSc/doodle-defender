using UnityEngine;

namespace Enemies {
    [RequireComponent(typeof(EnemyMovement))]
    public class Enemy : MonoBehaviour
    {
        #region Fields and Properties

        [field: SerializeField] public int CurrentHealth {get; private set;} = 1;

        #endregion

        #region Methods

        public void TakeDamage(int damage) {
            CurrentHealth -= damage;

            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
