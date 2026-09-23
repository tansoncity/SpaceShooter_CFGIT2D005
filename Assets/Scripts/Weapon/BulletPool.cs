using System;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;

    private ObjectPool<Bullet> _pool;

    public Action DoSomething;

    private void Awake() => _pool =
        new ObjectPool<Bullet>(
            CreateBullet,
            actionOnGet: x => x.Show(),
            actionOnRelease: x => x.Hide()
            );

    private Bullet CreateBullet()
    {
        var bullet = Instantiate(_bulletPrefab, transform);
        bullet.GetComponent<Explosive>().OnExploded.AddListener(
            () => _pool.Release(bullet));
        bullet.GetComponent<AutoDestroy>().OnTimeout.AddListener(
            () => _pool.Release(bullet));
        return bullet;
    }

    public Bullet Get() => _pool.Get();

    public void Release(Bullet bullet) => _pool.Release(bullet);
}
