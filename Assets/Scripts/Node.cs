using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 PositionOffset;

    [Header("Optional")]
    // You can set pre-placed turret here.
    public GameObject Turret;

    private Renderer _renderer;
    private Color _startColor;

    private BuildManager _buildManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }

    public Vector3 BuildPosition
    {
        get { return transform.position + PositionOffset; }
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!_buildManager.CanBuild)
            return;
        _renderer.material.color = HoverColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() || !_buildManager.CanBuild)
        {
            // Refund the money.
            PlayerStats.Money += _buildManager.TurretToBuild.Cost;
            Debug.Log("Money left: " + PlayerStats.Money);
            return;
        }

        if (Turret != null)
        {
            // Refund the money.
            PlayerStats.Money += _buildManager.TurretToBuild.Cost;
            Debug.Log("Money left: " + PlayerStats.Money);
            return;
        }

        _buildManager.BuildTurretOn(this);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}