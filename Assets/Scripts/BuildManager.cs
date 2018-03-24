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

    private void Start()
    {
        _turretToBuild = StandardTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }
}