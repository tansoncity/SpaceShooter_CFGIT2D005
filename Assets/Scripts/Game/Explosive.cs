using UnityEngine;
using UnityEngine.Events;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private bool _destroyOnExploded;

    public UnityEvent OnExploded;

    public void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        OnExploded?.Invoke();
        if (_destroyOnExploded)
        {
            Destroy(gameObject);
        }
    }
}
