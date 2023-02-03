using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public GameObject _bulletPrefab;
    public Transform _bulletSpawnPoint;
    public float _bulletForce = 10f;
    public Camera _camera;

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, GetComponent<Camera>().transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(_camera.transform.forward * _bulletForce, ForceMode.Impulse);
    }
}
