using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;

    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = new Vector3(target.GetBuildPosition().x, target.GetBuildPosition().y + 9f, target.GetBuildPosition().z);

        if(!target.isUpgraded)
        {
            if(target.turretBlueprint.upgradePrefab != null)
            {
                upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
                upgradeButton.interactable = true;
            }
            else
            {
                upgradeCost.text = "LOCK";
                upgradeButton.interactable = false;
            }
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
