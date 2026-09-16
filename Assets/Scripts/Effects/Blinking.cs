using UnityEngine;

public class Blinking : MonoBehaviour
{
    [SerializeField] private float _blinkingTime;
    [SerializeField] private bool _playOnAwake;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_playOnAwake)
        {
            StartBlinking();
        }
    }

    public void StartBlinking() 
        => InvokeRepeating(nameof(UpdateBlinking), 0, _blinkingTime);

    private void UpdateBlinking() => _renderer.enabled = !_renderer.enabled;

    public void StopBlinking() => CancelInvoke();
}
