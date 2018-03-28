using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    public float Speed = 70f;
    public float ExplosionRadius;
    public GameObject ImpactEffect;

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        var direction = _target.position - transform.position;
        float distanceThisFrame = Speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(_target);
    }

    private void HitTarget()
    {
        var effectInstantce = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstantce, 2f);
        Destroy(gameObject);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            // TODO add HP
            Damage(_target);
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (var collider1 in colliders)
        {
            if (collider1.CompareTag("Enemy"))
            {
                Damage(collider1.transform);
            }
        }
    }

    private static void Damage(Component enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}