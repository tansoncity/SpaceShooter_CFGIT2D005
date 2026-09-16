using UnityEngine;
using UnityEngine.Events;

public class HurtBox : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _explodeOnAnyCollision;

    public UnityEvent OnTriggered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(_damage);
            OnTriggered?.Invoke();
        }
        else if (_explodeOnAnyCollision)
        {
            OnTriggered?.Invoke();
        }
    }
}
