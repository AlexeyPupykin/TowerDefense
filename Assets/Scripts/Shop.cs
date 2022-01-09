using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint turretBullet;
    public TurretBlueprint turretRocket;
    public TurretBlueprint turretLaser;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurretBullet()
    {
        buildManager.SelectTurretToBuild(turretBullet);
    }


    public void SelectTurretRocket()
    {
        buildManager.SelectTurretToBuild(turretRocket);
    }

    public void SelectTurretLaser()
    {
        buildManager.SelectTurretToBuild(turretLaser);
    }

}
