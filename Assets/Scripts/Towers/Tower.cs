using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Towers {

    public class Tower : MonoBehaviour
    {
        #region Fields and Properties

        [field: SerializeField] public TowerData Data {get; private set;}
        private SpriteRenderer _renderer;
        private TowerUI _ui;

        private int _damageModification = 0;
        private int _speedModification = 0;
        private float _rangeModification = 0;

        #endregion

        #region Events

        private void OnEnable() {
            TowerUI.OnUIchange += UpdateUI;
        }

        private void OnDisable() {
            TowerUI.OnUIchange -= UpdateUI;
        }

        #endregion

        #region Methods

        private void Awake() {
            _renderer = GetComponentInChildren<SpriteRenderer>();
            _ui = GetComponent<TowerUI>();
        }

        private void Start() {
            Init(Data);
        }

        public void Init(TowerData data) {
            SetData(data);
            _renderer.sprite = data.TowerSprite;
            UpdateUI();
        }

        private void SetData(TowerData data) {
            Data = data;
        }

        private void UpdateUI() {
            var currentDamage = Data.AttackDamage + _damageModification;
            var currentSpeed = Data.AttackSpeed + _speedModification;
            var currentRange = Data.AttackRange + _rangeModification;
            _ui.UpdateUI(currentDamage, currentSpeed, currentRange);
        }

        #endregion
    }
}
