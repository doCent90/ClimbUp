using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    private Ray _rayMouse;
    private Camera _camera;
    private SuckerMover _suckerMover;

    private bool _isLimit = false;

    private void OnEnable()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        LimitMove();

        if (_isLimit)
            return;
        else
            TryMove();
    }

    private void TryMove()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit rayHit;
            var mousePos = Input.mousePosition;
            _rayMouse = _camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(_rayMouse, out rayHit))
            {
                if (rayHit.collider != null)
                {
                    if (rayHit.collider.TryGetComponent(out SuckerMover sucker) && sucker.enabled)
                    {
                        LimitMove();
                        sucker.SetTargetPosition();
                        _suckerMover = sucker;
                    }                    
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && _suckerMover != null && _suckerMover.enabled)
        {
            _suckerMover.MoveDone();
        }
    }

    private void LimitMove()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit rayHit;
            var mousePos = Input.mousePosition;
            _rayMouse = _camera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(_rayMouse, out rayHit))
            {
                if (rayHit.collider != null)
                {
                    if (rayHit.collider.TryGetComponent(out Wall wall))
                    {
                        _isLimit = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isLimit = false;
        }
    }
}
