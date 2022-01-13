using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTurrenItem : MonoBehaviour
{
    public CostBG costBG;

    void UpdateCost(string text)
    {
        costBG.UpdateText(text);
    }
}
