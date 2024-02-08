using UnityEngine;
using Enemies;


namespace Towers {

    public class Tower : MonoBehaviour
    {
        #region Fields and Properties

        [field: SerializeField] public TowerData Data {get; private set;}
        private SpriteRenderer _renderer;
        private TowerUI _ui;
        private RangeIndicator _rangeIndicator;
        private Enemy _targetEnemy;
        private float _attackCooldown = 0;

        [SerializeField] private Transform _attackSpawnPoint;

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
            _rangeIndicator = GetComponentInChildren<RangeIndicator>();
        }

        private void Start() {
            Init(Data);
            _rangeIndicator.gameObject.SetActive(false);
        }

        private void Update() {
            if (_targetEnemy != null && _attackCooldown >= (Data.AttackSpeed - _speedModification)) {
                Attack(_targetEnemy.transform);
                _attackCooldown = 0;
            }
            else {
                _attackCooldown += Time.deltaTime;
            }

            if (_targetEnemy == null) {
                _targetEnemy = GetClosestEnemy();
            }
        }

        public void Init(TowerData data) {
            SetData(data);
            UpdateUI();

            _renderer.sprite = data.TowerSprite;
            _attackCooldown = Data.AttackSpeed - _speedModification;
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

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, Data.AttackRange);    
        }

        private void OnMouseDown() {
            _rangeIndicator.gameObject.SetActive(true);
            _rangeIndicator.Init(_rangeModification + Data.AttackRange);
        }

        private void Attack(Transform target) {
            TowerAttack attack = Instantiate(Data.AttackPrefab, _attackSpawnPoint.position, Quaternion.identity);
            attack.Init(_damageModification + Data.AttackDamage, target);
        }

    	private Enemy GetClosestEnemy() {
            var enemies = TowerUtilities.GetEnemiesInRange(transform, Data.AttackRange + _rangeModification);
            
            if (enemies.Count == 0) {
                return null;
            }
            
            var closestEnemy = enemies[0];
            for (int i = 0; i < enemies.Count; i++) {
                var closestDistance = Vector2.Distance(transform.position, closestEnemy.transform.position);
                var contenderDistance = Vector2.Distance(transform.position, enemies[i].transform.position);

                closestEnemy = contenderDistance < closestDistance ? enemies[i] : closestEnemy;
            }
            return closestEnemy;
        }

        #endregion
    }
}
