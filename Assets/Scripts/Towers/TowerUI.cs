using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

namespace Towers {
    public class TowerUI : MonoBehaviour
    {
        #region Fields and Properties

        [SerializeField] private Canvas _statCanvas;
        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private TextMeshProUGUI _speed;
        [SerializeField] private TextMeshProUGUI _range;

        #endregion

        #region Events

        public static event Action OnUIchange;

        #endregion

        #region Methods

        private void Start() {
            GetComponentInChildren<Canvas>().worldCamera = Camera.main;
            _statCanvas.enabled = false;
        }

        public void UpdateUI(int damage, int speed, float range) {
            _statCanvas.enabled = true;
            _damage.text = damage.ToString();
            _speed.text = speed.ToString();
            _range.text = range.ToString();
        }

        #endregion
    }
}

