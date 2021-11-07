using UnityEngine;
using DG.Tweening;

public class HeadMover : MonoBehaviour
{
    private SuckerLeft _suckerLeft;
    private SuckerRight _suckerRight;

    private SuckerMover _left;
    private SuckerMover _rigth;

    private const float Duration = 0.5f;

    private void OnEnable()
    {
        _suckerLeft = FindObjectOfType<SuckerLeft>();
        _suckerRight = FindObjectOfType<SuckerRight>();

        _left = _suckerLeft.GetComponent<SuckerMover>();
        _rigth = _suckerRight.GetComponent<SuckerMover>();

        _left.Moved += Move;
        _rigth.Moved += Move;
    }

    private void OnDisable()
    {
        _left.Moved -= Move;
        _rigth.Moved -= Move;
    }

    private void Move(Transform transform)
    {
        var tweenLookAt = this.transform.DOLookAt(transform.position, Duration);
    }
}
