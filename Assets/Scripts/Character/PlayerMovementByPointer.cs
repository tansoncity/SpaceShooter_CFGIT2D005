using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementByPointer : MonoBehaviour
{
    private Camera _mainCamera;

    private void Start() => _mainCamera = Camera.main;

    void Update()
    {
        var screenPoint = Pointer.current.position.value;
        var worldPoint = _mainCamera.ScreenToWorldPoint(screenPoint);
        worldPoint.z = 0;
        transform.position = worldPoint;
    }
}
