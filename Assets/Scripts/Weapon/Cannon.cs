using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private float _cooldown;

    private InputAction _shootAction;
    private float _lastShotTime;

    private void Start()
    {
        _shootAction = InputSystem.actions["Attack"];
        _shootAction.Enable();
    }

    private void Update()
    {
        if (_shootAction.IsPressed() 
            && Time.time - _lastShotTime >= _cooldown)
        {
            Shoot();
            _lastShotTime = Time.time;
        }
    }

    private void Shoot()
    {
        var bullet = _bulletPool.Get();
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
