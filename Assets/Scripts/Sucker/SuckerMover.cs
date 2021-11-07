using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class SuckerMover : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _offset;
    private Suckers _suckers;
    private Rigidbody _rigidbody;
    private Transform _targetTemp;
    private Transform _targetPosition;
    private Transform _originalPosition;

    private float _distanceByScreen;
    private float _distanceBetweenSuckers;
    private int _multyply = 0;

    private const float CriticalDistance = 7f;

    public event UnityAction<Transform> Moved;

    public void SetTargetPosition()
    {
        if (_distanceBetweenSuckers > CriticalDistance)
            _multyply++;
        else
            _multyply = 0;

        if(_multyply % 5 == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    _targetTemp = hit.transform;
                    _offset = _targetTemp.position - hit.point;
                    _distanceByScreen = hit.distance;
                }
            }

            if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && _targetTemp != null)
            {
                Vector3 targetPosition;
                Ray rayPoint = _camera.ScreenPointToRay(Input.mousePosition);
                targetPosition = rayPoint.origin + rayPoint.direction * _distanceByScreen + _offset;
                _targetPosition.position = new Vector3(targetPosition.x, targetPosition.y, _originalPosition.position.z);
            }

            Move();

            if (Input.GetMouseButtonUp(0))
                _targetTemp = null;
        }

        if (_multyply > 1000)
            _multyply = 0;
    }

    private void Move()
    {
        float x = _targetPosition.position.x;
        float y = _targetPosition.position.y;
        float z = _originalPosition.position.z;

        transform.position = new Vector3(x, y, z);

        Moved?.Invoke(transform);
    }

    private void OnEnable()
    {
        _camera = FindObjectOfType<Camera>();
        _rigidbody = GetComponent<Rigidbody>();
        _suckers = GetComponentInParent<Suckers>();

        _originalPosition = transform;
        _targetPosition = _originalPosition;
    }
}