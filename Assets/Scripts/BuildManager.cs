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

    public TurretBlueprint TurretToBuild;

    public bool CanBuild
    {
        get { return TurretToBuild != null; }
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        TurretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        var turret = Instantiate(TurretToBuild.Prefab, node.BuildPosition, Quaternion.identity);
        node.Turret = turret;
        SetTurretToBuild(null);
    }
}