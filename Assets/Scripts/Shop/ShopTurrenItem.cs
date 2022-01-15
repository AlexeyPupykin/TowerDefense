using UnityEngine;

public class ShopTurrenItem : Shop
{
    public TurretBlueprint turret;

    public void CallSelectTurret()
    {
        SelectTurret(turret);
    }
}
