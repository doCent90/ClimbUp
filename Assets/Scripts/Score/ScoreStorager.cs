using UnityEngine;

[RequireComponent(typeof(ScoreViewer))]
public class ScoreStorager : MonoBehaviour
{
    private Coin[] _coins;
    private ScoreViewer _viewer;
    private int _countCoins = 0;

    private const string Coins = "Coins";

    public int CountCoins => _countCoins;

    private void OnEnable()
    {
        _coins = FindObjectsOfType<Coin>();
        _viewer = GetComponent<ScoreViewer>();

        foreach (var coin in _coins)
        {
            coin.Collected += OnCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var coin in _coins)
        {
            coin.Collected -= OnCollected;
        }

        int totalCoins = (_countCoins + PlayerPrefs.GetInt(Coins));
        PlayerPrefs.SetInt(Coins, totalCoins);
    }

    private void OnCollected()
    {
        _countCoins++;
        _viewer.ShowCount(_countCoins);
    }
}
