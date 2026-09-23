using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private bool _destroyOnTimeout;

    public UnityEvent OnTimeout;

    private void OnEnable() => Invoke(nameof(CallDestroy), _lifeTime);

    private void CallDestroy()
    {
        OnTimeout?.Invoke();
        if (_destroyOnTimeout)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable() => CancelInvoke();


}
