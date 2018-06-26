using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour {

    public TowerData _towerData;

    public void OnClick() {
        _towerData.Init();
        FindObjectOfType<GridPlacement>()._towerData = _towerData;
    }
}
