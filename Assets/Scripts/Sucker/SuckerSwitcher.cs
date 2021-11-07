using UnityEngine;

public class SuckerSwitcher : MonoBehaviour
{
    private SuckerLeft _suckerLeft;
    private SuckerRight _suckerRight;

    private SuckerMover _left;
    private SuckerMover _rigth;

    private int _count = 0;

    private void OnEnable()
    {
        _suckerLeft = GetComponentInChildren<SuckerLeft>();
        _suckerRight = GetComponentInChildren<SuckerRight>();

        _left = _suckerLeft.GetComponent<SuckerMover>();
        _rigth = _suckerRight.GetComponent<SuckerMover>();

        _count = Random.Range(0, 2);
        _left.MoveFinished += EnableRight;
        _rigth.MoveFinished += EnableLeft;

        EnableSuckerRandom();
    }

    private void OnDisable()
    {
        _left.MoveFinished -= EnableRight;
        _rigth.MoveFinished -= EnableLeft;
    }

    private void EnableSuckerRandom()
    {
        if (_count % 2 == 0) 
        {
            _left.enabled = true;
            _rigth.enabled = false;
        }
        else
        {
            _rigth.enabled = true;
            _left.enabled = false;
        }
    }

    private void EnableRight()
    {
        _rigth.enabled = true;
    }

    private void EnableLeft()
    {
        _left.enabled = true;
    }
}
