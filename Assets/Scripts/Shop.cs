using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager _buildmanager;

    private void Start()
    {
        _buildmanager = BuildManager.Instance;
    }

    public void PurchaseStandardTurret()
    {
        _buildmanager.SetTurretToBuild(_buildmanager.StandardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        _buildmanager.SetTurretToBuild(_buildmanager.MissileLauncherPrefab);
    }
}