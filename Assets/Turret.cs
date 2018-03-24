using UnityEngine;


public class Turret : MonoBehaviour
{
    private Transform _target;
    public float Range = 15f;

    public string EnemyTag = "Enemy";

    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(distanceToEnemy < shortestDistance)) continue;
            shortestDistance = distanceToEnemy;
            nearestEnemy = enemy;
        }

        if (nearestEnemy != null && shortestDistance <= Range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        var direction = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}