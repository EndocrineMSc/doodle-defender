using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

namespace Towers {
    public class TowerAttack : MonoBehaviour
    {
        #region Fields and Properties

        private int _damage;
        private Transform _visuals;
        private Transform _target;

        [SerializeField] private float _flyingSpeed;

        #endregion

        #region Methods

        private void Awake() {
            _visuals = transform.GetChild(0);
        }

        public void Init(int damage, Transform target) {
            _damage = damage;
            _target = target;
            UtilityLibrary.RotateTransformToFaceTarget2D(_visuals, _target);
        }

        private void Update() {
            if (_damage == 0) {
                Debug.LogError("Forgot to initialize attack or damage zero!");
                Destroy(gameObject);
            }
            else {
                UtilityLibrary.RotateTransformToFaceTarget2D(_visuals, _target);

                Vector2 direction = _target.position - transform.position;
                transform.Translate(direction.normalized * _flyingSpeed / 100); //divide by 100 for more sensible numbers
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.TryGetComponent<Enemy>(out Enemy enemy)) {
                enemy.TakeDamage(_damage);
                TriggerImpactPolish();
                Destroy(gameObject);
            }
        }

        private void TriggerImpactPolish() {
            //todo: SFX, Particle-Effect, Tweening?
        }

        #endregion
    }
}
