using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LevelViewer : MonoBehaviour
{
    private TMP_Text _text;

    private const string Level = "Level";

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        ShowLevel();
    }

    private void ShowLevel()
    {
        _text.text = PlayerPrefs.GetInt(Level).ToString();
    }
}
