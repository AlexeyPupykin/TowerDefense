using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint turretLarge;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("B");
        buildManager.SelectTurretToBuild(standartTurret);
    }


    public void SelectTurretLarge()
    {
        Debug.Log("B");
        buildManager.SelectTurretToBuild(turretLarge);
    }

}
