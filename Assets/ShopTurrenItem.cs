using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTurrenItem : Shop
{
    public TurretBlueprint turret;
    public GameObject costBG;

    public void CallSelectTurret()
    {
        base.SelectTurret(turret);
    }
}
