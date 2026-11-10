
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    private const string POINT_KEY = "NUSANTARA_RANK_POINTS";

    public int Points
    {
        get { return PlayerPrefs.GetInt(POINT_KEY, 0); }
    }

    public string GetRank()
    {
        if (Points >= 5000) return "CONQUEROR";
        if (Points >= 4000) return "DIAMOND";
        if (Points >= 3000) return "PLATINUM";
        if (Points >= 2000) return "GOLD";
        if (Points >= 1000) return "SILVER";

        return "BRONZE";
    }

    public void AddPoints(int amount)
    {
        if (amount <= 0) return;

        int newPoints = Points + amount;

        PlayerPrefs.SetInt(POINT_KEY, newPoints);
        PlayerPrefs.Save();

        Debug.Log("Rank: " + GetRank());
        Debug.Log("Poin: " + Points);
    }

    public void RemovePoints(int amount)
    {
        if (amount <= 0) return;

        int newPoints = Mathf.Max(0, Points - amount);

        PlayerPrefs.SetInt(POINT_KEY, newPoints);
        PlayerPrefs.Save();

        Debug.Log("Poin rank: " + Points);
    }

    public int GetPointsToNextRank()
    {
        int[] thresholds = { 1000, 2000, 3000, 4000, 5000 };

        foreach (int threshold in thresholds)
        {
            if (Points < threshold)
                return threshold - Points;
        }

        return 0;
    }
}
