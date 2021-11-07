using UnityEngine;

[RequireComponent(typeof(ButtonsUI))]
public class GameData : MonoBehaviour
{
    private Finish _finish;
    private Suckers _suckers;
    private ButtonsUI _buttonsUI;
    private ObjectSelector _objectSelector;

    private const int Stop = 0;
    private const int Start = 1;

    public bool IsGameStart { get; private set; } = false;

    private void OnEnable()
    {
        Time.timeScale = Stop;

        _finish = FindObjectOfType<Finish>();
        _suckers = FindObjectOfType<Suckers>();
        _buttonsUI = GetComponent<ButtonsUI>();
        _objectSelector = FindObjectOfType<ObjectSelector>();

        _buttonsUI.Started += Play;
        _finish.Finished += OnGameWin;
        _suckers.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _buttonsUI.Started -= Play;
        _finish.Finished -= OnGameWin;
        _suckers.GameOver -= OnGameOver;
    }

    private void Play()
    {
        Time.timeScale = Start;
        _objectSelector.enabled = true;
        IsGameStart = true;
    }

    private void OnGameWin()
    {
        _buttonsUI.ShowContinue();
        _objectSelector.enabled = false;
    }

    private void OnGameOver()
    {
        _buttonsUI.ShowRestart();
        _objectSelector.enabled = false;
    }
}
