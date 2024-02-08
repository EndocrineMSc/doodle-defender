using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Enemies {
    public class WaypointManager : MonoBehaviour
    {
        #region Fields and Properties

        public List<Transform> Waypoints {get; private set;} = new();
        public const string WAYPOINT_TAG = "Waypoint";

        #endregion

        #region Methods

        void Awake() {
            Waypoints = GetWaypoints();
        }

        List<Transform> GetWaypoints() {
            var unsortedWaypoints = GameObject.FindGameObjectsWithTag(WAYPOINT_TAG).ToList();
            var sortedWaypoints = unsortedWaypoints.OrderByDescending(a => a.transform.position.x);

            var sortedTransforms = new List<Transform>();
            foreach(var waypoint in sortedWaypoints) {
                sortedTransforms.Add(waypoint.transform);
            }
            return sortedTransforms;
        }

        #endregion
    }
}
