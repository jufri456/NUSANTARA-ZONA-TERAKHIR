
using UnityEngine;

public class MatchStatsManager : MonoBehaviour
{
    public PlayerProfileManager profileManager;
    public RankSystem rankSystem;

    public MatchStatsData stats = new MatchStatsData();

    private bool matchActive;

    private const string STATS_KEY = "LAST_MATCH_STATS";

    public void StartMatch()
    {
        stats = new MatchStatsData();
        matchActive = true;

        Debug.Log("Pertandingan dimulai!");
    }

    private void Update()
    {
        if (matchActive)
        {
            stats.survivalSeconds += Time.deltaTime;
        }
    }

    public void RecordKill()
    {
        if (!matchActive) return;

        stats.kills++;
        stats.playersEliminated++;

        if (profileManager != null)
            profileManager.AddKill();
    }

    public void RecordDamageDealt(float damage)
    {
        if (!matchActive || damage <= 0) return;

        stats.damageDealt += damage;
    }

    public void RecordDamageReceived(float damage)
    {
        if (!matchActive || damage <= 0) return;

        stats.damageReceived += damage;
    }

    public void CompleteMatch(bool victory)
    {
        if (!matchActive) return;

        matchActive = false;
        stats.won = victory;
        stats.result = victory ? "VICTORY" : "DEFEAT";

        if (profileManager != null)
        {
            profileManager.AddMatch();

            if (victory)
                profileManager.AddWin();
        }

        if (rankSystem != null)
        {
            rankSystem.AddPoints(victory ? 100 : 10);
        }

        string json = JsonUtility.ToJson(stats);

        PlayerPrefs.SetString(STATS_KEY, json);
        PlayerPrefs.Save();

        Debug.Log("Pertandingan selesai: " + stats.result);
    }

    public MatchStatsData LoadLastMatch()
    {
        if (!PlayerPrefs.HasKey(STATS_KEY))
            return null;

        string json = PlayerPrefs.GetString(STATS_KEY);

        return JsonUtility.FromJson<MatchStatsData>(json);
    }
}
