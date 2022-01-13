using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public int cost;
    public int upgradeCost;
    public GameObject prefab;
    public GameObject upgradePrefab;
    public GameObject placeholderPrefab;
    public Sprite image;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
