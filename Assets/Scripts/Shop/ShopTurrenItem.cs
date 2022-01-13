using UnityEngine;

public class ShopTurrenItem : Shop
{
    public TurretBlueprint turret;
    public GameObject costBG;

    public void CallSelectTurret()
    {
        SelectTurret(turret);
    }
}
