using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Instantialise singleton.
    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene.");
            return;
        }

        Instance = this;
    }

    public GameObject StandardTurretPrefab;
    private GameObject _turretToBuild;

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
    
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }   
}