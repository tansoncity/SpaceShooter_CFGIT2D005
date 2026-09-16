using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementByKey : MonoBehaviour
{
    [SerializeField] private float _speed = 1; // default = 1

    private InputAction _moveInput;

    private void Start()
    {
        _moveInput = InputSystem.actions["Move"];
        _moveInput.Enable();
    }

    void Update()
    {
        var direction = _moveInput.ReadValue<Vector2>();
        var distance = _speed * Time.deltaTime * direction;
        transform.Translate(distance);
    }
}
