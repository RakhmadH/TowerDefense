using UnityEngine;

public class Shop : MonoBehaviour
{
    public static BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
        Debug.Log("Standard turret selected.");
    }

    public void PurchaseAnotherTurret()
    {
        buildManager.SetTurretToBuild(buildManager.anotherTurretPrefab);
        Debug.Log("Another turret selected.");
    }
}

    

