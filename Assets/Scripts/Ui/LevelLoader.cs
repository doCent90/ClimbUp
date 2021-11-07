using UnityEngine;
using IJunior.TypedScenes;

[RequireComponent(typeof(ButtonsUI))]
public class LevelLoader : MonoBehaviour
{
    private ButtonsUI _buttonsUI;

    private void OnEnable()
    {
        _buttonsUI = GetComponent<ButtonsUI>();

        _buttonsUI.Restarted += Restart;
        _buttonsUI.Continued += Continue;
    }

    private void OnDisable()
    {
        _buttonsUI.Restarted -= Restart;
        _buttonsUI.Continued -= Continue;
    }

    private void Restart()
    {
        LVL1.Load();
    }

    private void Continue()
    {
        LVL1.Load();
    }
}
