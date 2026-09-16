using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;

    public void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
