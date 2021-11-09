using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class BankCoinsViewer : MonoBehaviour
{
    private TMP_Text _text;

    private const string Coins = "Coins";

    public void AddCoin()
    {
        int addCoin = PlayerPrefs.GetInt(Coins) + 1;
        PlayerPrefs.SetInt(Coins, addCoin);

        Show();
    }

    private void OnEnable()
    {
        _text = GetComponent<TMP_Text>();
        Show();
    }

    private void Show()
    {
        _text.text = $"Bank: {PlayerPrefs.GetInt(Coins).ToString()}";
    }
}
