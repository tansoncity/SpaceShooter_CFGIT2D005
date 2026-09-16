using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _score;
    [SerializeField] private Health _health;

    public static Action<int> EnemyKilled;
    public static Action<int> EnemyScored;
    public static Action EnemyDestroyed;

    private void Start()
    {
        _health.TookDamage += TakeDamage;
    }

    public void TakeDamage(int damage)
    {
        EnemyScored(damage);
    }

    //public void OnKilled() => EnemyKilled?.Invoke(
    //    _health.FullHealthPoint * 2);

    public void Disapear() => Destroy(gameObject);

    private void OnDestroy() => EnemyDestroyed?.Invoke();
}
