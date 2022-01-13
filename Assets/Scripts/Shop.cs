using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<TurretBlueprint> items;
    //public TurretBlueprint turretBullet;
    //public TurretBlueprint turretRocket;
    //public TurretBlueprint turretLaser;
    public ShopTurrenItem shopTurretItem;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        foreach (var item in items)
        {
            shopTurretItem.turret = item;
            shopTurretItem.GetComponent<Image>().sprite = item.image;
            shopTurretItem.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>().text = "$" + item.cost;

            var go = Instantiate(shopTurretItem);            
            go.transform.parent = gameObject.transform; 
        }
    }

    public void SelectTurret(TurretBlueprint turret)
    {
        buildManager.SelectTurretToBuild(turret);
    }

    //public void SelectTurretBullet()
    //{
    //    buildManager.SelectTurretToBuild(turretBullet);
    //}


    //public void SelectTurretRocket()
    //{
    //    buildManager.SelectTurretToBuild(turretRocket);
    //}

    //public void SelectTurretLaser()
    //{
    //    buildManager.SelectTurretToBuild(turretLaser);
    //}

}
