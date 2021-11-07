using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction Collected;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent(out SuckerLeft suckerLeft) || collision.TryGetComponent(out SuckerRight suckerRight))
        {
            Collected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
