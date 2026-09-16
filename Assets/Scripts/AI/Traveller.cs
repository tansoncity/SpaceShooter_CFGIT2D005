using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class Traveller : MonoBehaviour
{
    [SerializeField] private SplineContainer _route;
    [SerializeField] private float _speed;
    [SerializeField] private float _startDistance;

    public UnityEvent OnDestinationReached;

    private float _pathLength;
    private float _distance;

    public void SetRoute(SplineContainer route) => _route = route;

    public void SetStartDistance(float distance)
        => _startDistance = distance;

    private void Start() => StartCoroutine(FollowPath());

    private IEnumerator FollowPath()
    {
        if (_route == null) yield break;

        _pathLength = _route.Spline.GetLength();
        _distance = _startDistance;
        while (_distance < _pathLength)
        {
            UpdatePositionByDistance();
            _distance += _speed * Time.deltaTime;
            yield return null;
        }

        OnDestinationReached?.Invoke();
    }

    private void UpdatePositionByDistance()
    {
        var t = _distance / _pathLength;
        var newPosition = (Vector3)_route.Spline.EvaluatePosition(t);
        transform.position = newPosition + _route.transform.position;
        transform.up = -_route.Spline.EvaluateTangent(t);
    }
}
