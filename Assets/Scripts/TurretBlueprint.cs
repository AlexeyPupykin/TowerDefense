using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public GameObject placeholderPrefab;

    public Sprite image;
    
    public int GetSellAmount()
    {
        return cost / 2;
    }
}
