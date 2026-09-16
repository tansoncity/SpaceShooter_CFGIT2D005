using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthValue;
    [SerializeField] private Health _health;
    [SerializeField] private float _visibleTime;
    [SerializeField] private bool _disableShowHide;

    private void Start()
    {
        _health.OnChanged.AddListener(() =>
        {
            ApplyHealth();
            Show();
        });

        ApplyHealth();
        Hide();
    }

    private void ApplyHealth()
        => _healthValue.fillAmount = _health.FillAmount;

    private void Show()
    {
        if (_disableShowHide) return;

        gameObject.SetActive(true);
        Invoke(nameof(Hide), _visibleTime);
    }

    private void Hide()
    {
        if (_disableShowHide) return;

        gameObject.SetActive(false);
    }
}
