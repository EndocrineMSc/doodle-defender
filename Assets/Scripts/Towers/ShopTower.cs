using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Towers {
    public class ShopTower : MonoBehaviour, IDragHandler
    {
        #region Fields and Properties

        [field: SerializeField] public TowerData Data {get; private set;}
        private RectTransform _rectTransform;
        private Canvas _canvas;

        #endregion

        #region Methods

        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = transform.parent.GetComponent<Canvas>();
        }

        public void OnDrag(PointerEventData eventData) {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        #endregion

    }
}
