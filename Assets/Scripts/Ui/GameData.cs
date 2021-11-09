using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ButtonsUI))]
public class GameData : MonoBehaviour
{
    private FailText _failText;
    private CompletedText _completeText;
    private Finish _finish;
    private Suckers _suckers;
    private ButtonsUI _buttonsUI;
    private ObjectSelector _objectSelector;

    private int _countLevelDone = 0;

    private const int Stop = 0;
    private const int Start = 1;
    private const string Level = "Level";

    public bool IsGameStart { get; private set; } = false;

    private void OnEnable()
    {
        Time.timeScale = Stop;

        _finish = FindObjectOfType<Finish>();
        _suckers = FindObjectOfType<Suckers>();
        _buttonsUI = GetComponent<ButtonsUI>();
        _objectSelector = FindObjectOfType<ObjectSelector>();

        _failText = FindObjectOfType<FailText>();
        _completeText = FindObjectOfType<CompletedText>();

        _failText.gameObject.SetActive(false);
        _completeText.gameObject.SetActive(false);

        _countLevelDone = PlayerPrefs.GetInt(Level);

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
        _countLevelDone++;
        PlayerPrefs.SetInt(Level, _countLevelDone);
        _buttonsUI.ShowContinue();
        _objectSelector.enabled = false;
        _completeText.gameObject.SetActive(true);
    }

    private void OnGameOver()
    {
        _buttonsUI.ShowRestart();
        _objectSelector.enabled = false;
        _failText.gameObject.SetActive(true);
    }
}
