using UnityEngine;
using TMPro;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;

    public void ShowCount(int score)
    {
        _score.text = score.ToString();
    }
}