using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _shootingTarget;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _bulletPrefab;
    [SerializeField] private float _shootingDelay;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    public void SetTarget(Transform target)
    {
        _shootingTarget = target;
    }

    private IEnumerator Shoot()
    {
        bool isWork = enabled;
        WaitForSeconds delay = new WaitForSeconds(_shootingDelay);

        while (isWork)
        {
            Vector3 direction = (_shootingTarget.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.velocity = direction * _speed;

            yield return delay;
        }
    }
}