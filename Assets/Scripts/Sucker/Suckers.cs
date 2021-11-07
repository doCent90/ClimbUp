using UnityEngine;
using UnityEngine.Events;

public class Suckers : MonoBehaviour
{
    private SuckerLeft _left;
    private SuckerRight _right;
    private CharacterJoint _characterJointLeft;
    private CharacterJoint _characterJointRigth;

    private const float Distance = 10f;

    public event UnityAction<float> DistaceChanged;

    private void OnEnable()
    {
        _left = GetComponentInChildren<SuckerLeft>();
        _right = GetComponentInChildren<SuckerRight>();
        _characterJointLeft = _left.GetComponentInChildren<CharacterJoint>();
        _characterJointRigth = _right.GetComponentInChildren<CharacterJoint>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(_left.transform.position, _right.transform.position);
        DistaceChanged?.Invoke(distance);

        if (distance > Distance)
            DisableJoints();
    }

    private void DisableJoints()
    {
        if(_characterJointLeft != null && _characterJointRigth != null)
        {
            _characterJointLeft.breakForce = 0f;
            _characterJointRigth.breakForce = 0f;
            enabled = false;
        }
    }
}
