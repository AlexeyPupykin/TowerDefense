using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer renderer;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;

        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Already builded");
            return;
        }

        GameObject turrentToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }
}
