using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public List<TurretBlueprint> items;
    public TurretBlueprint turretBullet;
    public TurretBlueprint turretRocket;
    public TurretBlueprint turretLaser;
    public ShopTurrenItem shopTurretItem;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        foreach (var item in items)
        {
            var tur = item;
            var image = shopTurretItem.GetComponent<Image>();
            image.sprite = item.image;
            var button = shopTurretItem.GetComponent<Button>();
            button.onClick.AddListener(delegate { SelectTurret(tur); });
            //button.onClick.AddListener(delegate { SwitchButtonHandler(0); });
            var go = Instantiate(shopTurretItem);
            go.transform.parent = gameObject.transform;
            
        }
    }

    public void SelectTurret(TurretBlueprint turret)
    {
        buildManager.SelectTurretToBuild(turret);
    }

    void SwitchButtonHandler(int idx_)
    {
        Debug.Log(idx_);
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
