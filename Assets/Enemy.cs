using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 10f;

    private Transform _target;
    private int _waypointIndex;

    private void Start()
    {
        _target = Waypoints.Points[0];
    }

    private void Update()
    {
        var direction = _target.position - transform.position;
        transform.Translate(direction.normalized * Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) <= .2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (_waypointIndex >= Waypoints.Points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        _waypointIndex++;
        _target = Waypoints.Points[_waypointIndex];
    }
}