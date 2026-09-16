using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField] private Color _color = Color.white;
    [SerializeField] private Transform[] _waypoints;

    public Vector3 this[int index] => _waypoints[index].position;
    public int Count => _waypoints?.Length ?? 0;

    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        if (_waypoints == null) return;
        
        for (int i = 0; i < _waypoints.Length - 1; i++)
        {
            Gizmos.DrawLine(_waypoints[i].position, 
                _waypoints[i + 1].position);
        }
    }
}
