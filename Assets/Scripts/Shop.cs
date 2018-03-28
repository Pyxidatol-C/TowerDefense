using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissileLauncher;
    private BuildManager _buildmanager;

    private void Start()
    {
        _buildmanager = BuildManager.Instance;
    }

    public void PurchaseStandardTurret()
    {
        if (PlayerStats.Money < StandardTurret.Cost)
        {
            Debug.Log("Nope.");
            return;
        }
        _buildmanager.SetTurretToBuild(StandardTurret);
        PlayerStats.Money -= StandardTurret.Cost;
        Debug.Log("Money left: " + PlayerStats.Money);
    }

    public void PurchaseMissileLauncher()
    {
        if (PlayerStats.Money < StandardTurret.Cost)
        {
            Debug.Log("Nope.");
            return;
        }
        _buildmanager.SetTurretToBuild(MissileLauncher);
        PlayerStats.Money -= MissileLauncher.Cost;
        Debug.Log("Money left: " + PlayerStats.Money);
    }
}