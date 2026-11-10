

using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{
    public LeaderboardManager leaderboard;

    public void ShowTop10()
    {
        if (leaderboard == null)
            return;

        var topPlayers = leaderboard.GetTopPlayers(10);

        Debug.Log("===== TOP 10 NUSANTARA =====");

        for (int i = 0; i < topPlayers.Count; i++)
        {
            Debug.Log(
                (i + 1) + ". " +
                topPlayers[i].playerName +
                " | Kill: " + topPlayers[i].kills +
                " | Poin: " + topPlayers[i].rankPoints
            );
        }
    }
}
