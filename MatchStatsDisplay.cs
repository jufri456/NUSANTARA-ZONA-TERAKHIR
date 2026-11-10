
using UnityEngine;

public class MatchStatsDisplay : MonoBehaviour
{
    public MatchStatsManager statsManager;

    public void ShowLastMatch()
    {
        if (statsManager == null) return;

        MatchStatsData data = statsManager.LoadLastMatch();

        if (data == null)
        {
            Debug.Log("Belum ada statistik pertandingan.");
            return;
        }

        Debug.Log("===== HASIL PERTANDINGAN =====");
        Debug.Log("Hasil: " + data.result);
        Debug.Log("Kill: " + data.kills);
        Debug.Log("Eliminasi: " + data.playersEliminated);
        Debug.Log("Damage diberikan: " + data.damageDealt);
        Debug.Log("Damage diterima: " + data.damageReceived);
        Debug.Log("Waktu bertahan: " + data.survivalSeconds + " detik");
    }
}
