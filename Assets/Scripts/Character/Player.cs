using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _immortalDuration;
    [SerializeField] private Blinking _blinking;

    public void StartImmortal()
    {
        _collider.enabled = false;
        _blinking.StartBlinking();
        Invoke(nameof(StopImmortal), _immortalDuration);
    }

    private void StopImmortal()
    {
        _collider.enabled = true;
        _blinking.StopBlinking();
    }
}
