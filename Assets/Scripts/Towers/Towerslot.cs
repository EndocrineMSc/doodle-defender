using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Towers {
    public class Towerslot : MonoBehaviour, IDropHandler
    {
        #region Fields and Properties

        [SerializeField] private Tower _tower;

        #endregion

        #region Methods

        public void OnDrop(PointerEventData eventData) {
            eventData.pointerDrag.TryGetComponent(out ShopTower shopTower);

            if (shopTower) {
                _tower.Init(shopTower.Data);
            }

            Destroy(eventData.pointerDrag);
        }

        #endregion
    }
}
