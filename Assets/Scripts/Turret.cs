using UnityEngine;


public class Turret : MonoBehaviour
{
    private Transform _target;

    [Header("Attrubutes")]
    // Turret attributes.
    public float Range = 15f;

    // Number of bullets fired per second.
    public float FireRate = 1f;
    private float _fireCountDown = 0.25f;

    [Header("Unity Setup Fields")]
    // Fields that have to do with Unity.
    public string EnemyTag = "Enemy";

    public Transform PartToRotate;
    public float TurnSpeed = 10f;

    public GameObject BulletPrefab;
    public Transform FirePoint;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        if (_target != null && Vector3.Distance(transform.position, _target.position) <= Range)
        {
            return;
        }

        var enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy >= shortestDistance) continue;
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

        // Handle target lock-on.
        var direction = _target.position - transform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(PartToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        // Handle firing.
        if (_fireCountDown <= 0)
        {
            Shoot();
            _fireCountDown = 1 / FireRate;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGameObj = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        var bullet = bulletGameObj.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}