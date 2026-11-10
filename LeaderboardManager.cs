
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class LeaderboardData
{
    public List<LeaderboardEntry> players =
        new List<LeaderboardEntry>();
}

public class LeaderboardManager : MonoBehaviour
{
    private const string SAVE_KEY = "NUSANTARA_LEADERBOARD";

    public List<LeaderboardEntry> players =
        new List<LeaderboardEntry>();

    private void Awake()
    {
        LoadLeaderboard();
    }

    public void AddOrUpdatePlayer(
        string playerName,
        int kills,
        int rankPoints)
    {
        if (string.IsNullOrEmpty(playerName))
            return;

        LeaderboardEntry player = players.Find(
            p => p.playerName == playerName
        );

        if (player == null)
        {
            player = new LeaderboardEntry(
                playerName, kills, rankPoints
            );

            players.Add(player);
        }
        else
        {
            player.kills = kills;
            player.rankPoints = rankPoints;
        }

        SortLeaderboard();
        SaveLeaderboard();
    }

    public void SortLeaderboard()
    {
        players = players
            .OrderByDescending(p => p.rankPoints)
            .ThenByDescending(p => p.kills)
            .ToList();
    }

    public List<LeaderboardEntry> GetTopPlayers(int amount)
    {
        SortLeaderboard();

        int count = Mathf.Clamp(amount, 0, players.Count);

        return players.GetRange(0, count);
    }

    private void SaveLeaderboard()
    {
        LeaderboardData data = new LeaderboardData();
        data.players = players;

        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
            return;

        string json = PlayerPrefs.GetString(SAVE_KEY);
        LeaderboardData data =
            JsonUtility.FromJson<LeaderboardData>(json);

        if (data != null && data.players != null)
            players = data.players;

        SortLeaderboard();
    }
}
