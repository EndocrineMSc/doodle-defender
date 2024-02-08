using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemies {
    public class EnemyMovement : MonoBehaviour
    {
        #region Fields and Properties

        [SerializeField] private float _speed;
        private int _waypointIndex = 0;
        private readonly float _arrivedThreshold = 0.2f;

        #endregion

        #region Methods

        void Update() {
            Move();
            HandleEndArrival();
        }   

        void Move() {
            var currentTarget = WaypointManager.Instance.Waypoints[_waypointIndex].position;

            Vector2 direction = currentTarget - transform.position;
            transform.Translate(direction.normalized * _speed / 100); //division by 100 for bigger speed numbers

            if (Vector2.Distance(transform.position, currentTarget) < _arrivedThreshold) {
                _waypointIndex++;
            }
        }

        void HandleEndArrival() {
            if (_waypointIndex >= WaypointManager.Instance.Waypoints.Count) {
                //todo: Player loses life
                Destroy(gameObject);
            }
        }

        #endregion
    }
}
