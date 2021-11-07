using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(GameData))]
public class ButtonsUI : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _continue;
    [Header("Shop")]
    [SerializeField] private GameObject _shop;
    [SerializeField] private Button _openShop;
    [SerializeField] private Button _closeShop;

    private GameData _gameData;

    public event UnityAction Started;
    public event UnityAction Restarted;
    public event UnityAction Continued;

    public void Play()
    {
        Started?.Invoke();
        _play.gameObject.SetActive(false);
    }

    public void Restart()
    {
        Restarted?.Invoke();
        _restart.gameObject.SetActive(false);
    }

    public void ShowRestart()
    {
        _restart.gameObject.SetActive(true);
    }

    public void Continue()
    {
        Continued?.Invoke();
        _continue.gameObject.SetActive(false);
    }

    public void ShowContinue()
    {
        _continue.gameObject.SetActive(true);
    }

    public void OpenShop()
    {
        Time.timeScale = 0;

        _shop.SetActive(true);
        _openShop.gameObject.SetActive(false);
        _closeShop.gameObject.SetActive(true);
    }

    public void CloseShop()
    {
        if(_gameData.IsGameStart)
            Time.timeScale = 1;

        _shop.SetActive(false);
        _openShop.gameObject.SetActive(true);
        _closeShop.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _gameData = GetComponent<GameData>();
    }
}
