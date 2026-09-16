using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [FormerlySerializedAs("FullHealthPoint")]
    [SerializeField] private int _fullHealthPoint;

    public UnityEvent OnDead;
    public UnityEvent OnChanged;
    public UnityEvent OnTakeDamage;

    public Action<int> TookDamage;

    public int FullHealthPoint => _fullHealthPoint;
    public float FillAmount
        => FullHealthPoint == 0 ? 0f : (float)HealthPoint / FullHealthPoint; 

    private int _healthPoint;
    public int HealthPoint
    {
        get => _healthPoint;
        set
        {
            _healthPoint = Mathf.Clamp(value, 0, FullHealthPoint);
            OnChanged?.Invoke();
        }
    }

    public bool IsDead => HealthPoint <= 0;

    private void Start() => HealthPoint = _fullHealthPoint;

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        HealthPoint -= damage;
        OnTakeDamage?.Invoke();
        TookDamage?.Invoke(damage); ;
        if (IsDead)
        {
            Die();
        }
    }

    private void Die() => OnDead?.Invoke();
}
