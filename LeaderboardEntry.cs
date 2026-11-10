
using System;

[Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public int kills;
    public int rankPoints;

    public LeaderboardEntry(string name, int killCount, int points)
    {
        playerName = name;
        kills = killCount;
        rankPoints = points;
    }
}
