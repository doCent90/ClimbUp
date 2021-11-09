using UnityEngine;
using UnityEngine.Events;

public class Finish : MonoBehaviour
{
    public event UnityAction Finished;

    private bool _isLeftEnter = false;
    private bool _isRightEnter = false;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out SuckerLeft suckerLeft))
        {
            _isLeftEnter = true;
            FinishGame();
        }

        if (collision.TryGetComponent(out SuckerRight suckerRight))
        {
            _isRightEnter = true;
            FinishGame();
        }
    }

    private void FinishGame()
    {
        if(_isLeftEnter && _isRightEnter)
            Finished?.Invoke();
    }
}
