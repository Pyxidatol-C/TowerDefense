using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

    public float Speed = 70f;
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
    }

    private void HitTarget()
    {
        var effectInstantce = Instantiate(ImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstantce, 1f);
        Destroy(gameObject);

        // TODO add HP
        Destroy(_target.gameObject);
    }
}