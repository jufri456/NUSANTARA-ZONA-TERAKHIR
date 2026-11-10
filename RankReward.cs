
using UnityEngine;

public class RankReward : MonoBehaviour
{
    public PlayerWallet wallet;
    public RankSystem rankSystem;

    public void ClaimRankReward()
    {
        if (wallet == null || rankSystem == null)
            return;

        string rank = rankSystem.GetRank();
        string key = "RANK_REWARD_" + rank;

        if (PlayerPrefs.GetInt(key, 0) == 1)
        {
            Debug.Log("Hadiah rank sudah diklaim!");
            return;
        }

        int reward = 0;

        switch (rank)
        {
            case "BRONZE": reward = 100; break;
            case "SILVER": reward = 250; break;
            case "GOLD": reward = 500; break;
            case "PLATINUM": reward = 1000; break;
            case "DIAMOND": reward = 2000; break;
            case "CONQUEROR": reward = 5000; break;
        }

        wallet.AddCoins(reward);

        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();

        Debug.Log("Hadiah " + rank + " diterima!");
    }
}
