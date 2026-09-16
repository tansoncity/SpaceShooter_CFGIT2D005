using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void Update() => ApplyHealthValue();

    public void ApplyHealthValue() => _slider.value = _health.FillAmount;
}
