using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 PositionOffset;

    private GameObject _turret;

    private Renderer _renderer;
    private Color _startColor;

    private BuildManager _buildManager;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
        _buildManager = BuildManager.Instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_buildManager.GetTurretToBuild() == null)
            return;
        _renderer.material.color = HoverColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (_buildManager.GetTurretToBuild() == null)
            return;
        if (_turret != null)
        {
            // TODO display on screen
            Debug.Log("NOPE.");
            return;
        }

        // Build a turret.
        var turretToBuild = _buildManager.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + PositionOffset, transform.rotation);
        _buildManager.SetTurretToBuild(null);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}