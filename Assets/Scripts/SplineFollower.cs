using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] private SplineContainer _spline;
    [SerializeField] private float _speed;

    private float _distance;
    private float _pathLength;

    private void Start()
    {
        _pathLength = _spline.Spline.GetLength();
        _distance = -5f;
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath()
    {
        while (_distance < _pathLength)
        {
            UpdatePositionByDistance();
            _distance += _speed * Time.deltaTime;
            yield return null;
        }
    }

    private void UpdatePositionByDistance()
    {
        var t = _distance / _pathLength;
        var newPosition = (Vector3)_spline.Spline.EvaluatePosition(t);
        transform.position = newPosition + _spline.transform.position;
    }
}
