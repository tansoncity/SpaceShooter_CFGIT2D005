using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update() => transform.Translate(0, _speed * Time.deltaTime, 0);
}
