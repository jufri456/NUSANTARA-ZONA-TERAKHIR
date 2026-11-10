
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int startingCoins = 500;

    private const string CoinKey = "NUSANTARA_COINS";

    public int Coins
    {
        get { return PlayerPrefs.GetInt(CoinKey, startingCoins); }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey(CoinKey))
        {
            PlayerPrefs.SetInt(CoinKey, startingCoins);
            PlayerPrefs.Save();
        }
    }

    public void AddCoins(int amount)
    {
        if (amount <= 0) return;

        PlayerPrefs.SetInt(CoinKey, Coins + amount);
        PlayerPrefs.Save();

        Debug.Log("Koin sekarang: " + Coins);
    }

    public bool SpendCoins(int amount)
    {
        if (amount <= 0 || Coins < amount)
            return false;

        PlayerPrefs.SetInt(CoinKey, Coins - amount);
        PlayerPrefs.Save();

        Debug.Log("Pembelian berhasil. Sisa koin: " + Coins);
        return true;
    }
}
