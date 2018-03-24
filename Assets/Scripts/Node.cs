using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 PositionOffset;

    private GameObject _turret;

    private Renderer _renderer;
    private Color _startColor;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _startColor = _renderer.material.color;
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = HoverColor;
    }

    private void OnMouseDown()
    {
        if (_turret != null)
        {
            // TODO display on screen
            Debug.Log("NOPE.");
            return;
        }

        // Build a turret.
        var turretToBuild = BuildManager.Instance.GetTurretToBuild();
        _turret = Instantiate(turretToBuild, transform.position + PositionOffset, transform.rotation);
    }

    private void OnMouseExit()
    {
        _renderer.material.color = _startColor;
    }
}