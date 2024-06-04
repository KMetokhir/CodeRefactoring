using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pathContainer;

    private Transform[] _path;
    private int _currentPathPointIndex;

    private void Start()
    {
        CreatePath();
    }

    private void Update()
    {
        Transform point = _path[_currentPathPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
        {
            SetNextPathPoint();
            Rotate();
        }
    }

    public void SetNextPathPoint()
    {
        _currentPathPointIndex++;

        if (_currentPathPointIndex == _path.Length)
        {
            _currentPathPointIndex = 0;
        }
    }

    private void Rotate()
    {
        Vector3 thisPointVector = _path[_currentPathPointIndex].transform.position;
        transform.forward = thisPointVector - transform.position;
    }

    private void CreatePath()
    {
        int pointsCount = _pathContainer.childCount;
        _path = new Transform[pointsCount];

        for (int i = 0; i < pointsCount; i++)
        {
            _path[i] = _pathContainer.GetChild(i).GetComponent<Transform>();
        }
    }
}