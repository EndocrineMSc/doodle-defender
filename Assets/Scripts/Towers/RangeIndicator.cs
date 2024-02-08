using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towers {

    public class RangeIndicator : MonoBehaviour
    {
        #region Fields and Properties

        private float _range;
        private readonly int _segments = 50;
        private LineRenderer _lineRenderer;

        #endregion

        #region Methods

        private void Start() {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void Init(float range) {
            _range = range;
            UpdateRangeIndicator();
        }

        private void UpdateRangeIndicator() {
            _lineRenderer.positionCount = _segments + 1;

            float deltaTheta = 2f * Mathf.PI / _segments;
            float theta = 0f;

            for (int i = 0; i < _segments + 1; i++)
            {
                float x = _range * Mathf.Cos(theta);
                float y = _range * Mathf.Sin(theta);

                _lineRenderer.SetPosition(i, new Vector3(x, y, 0f));

                theta += deltaTheta;
            }
        }

        #endregion
    }
}
