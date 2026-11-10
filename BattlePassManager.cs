
using UnityEngine;

public class BattlePassManager : MonoBehaviour
{
    public PlayerWallet wallet;

    public int xpPerLevel = 100;
    public int maxLevel = 50;

    private const string XP_KEY = "NUSANTARA_BP_XP";

    public int TotalXP
    {
        get { return PlayerPrefs.GetInt(XP_KEY, 0); }
    }

    public int CurrentLevel
    {
        get
        {
            return Mathf.Clamp(
                (TotalXP / xpPerLevel) + 1,
                1,
                maxLevel
            );
        }
    }

    public int XPProgress
    {
        get { return TotalXP % xpPerLevel; }
    }

    public void AddXP(int amount)
    {
        if (amount <= 0) return;

        int newXP = TotalXP + amount;
        int maximumXP = maxLevel * xpPerLevel;

        PlayerPrefs.SetInt(XP_KEY, Mathf.Min(newXP, maximumXP));
        PlayerPrefs.Save();

        Debug.Log("XP Battle Pass: " + TotalXP);
        Debug.Log("Level Battle Pass: " + CurrentLevel);
    }

    public bool ClaimCoins(int level, int coinReward)
    {
        if (level < 1 || level > CurrentLevel)
            return false;

        if (coinReward <= 0 || wallet == null)
            return false;

        string key = "BP_CLAIMED_" + level;

        if (PlayerPrefs.GetInt(key, 0) == 1)
            return false;

        wallet.AddCoins(coinReward);

        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

        Debug.Log("Hadiah Battle Pass berhasil diklaim!");
        return true;
    }

    public bool IsClaimed(int level)
    {
        return PlayerPrefs.GetInt(
            "BP_CLAIMED_" + level, 0
        ) == 1;
    }
}
