
using UnityEngine;

public class PlayerProfileDisplay : MonoBehaviour
{
    public PlayerProfileManager profileManager;
    public RankSystem rankSystem;

    public void ShowProfile()
    {
        if (profileManager == null ||
            profileManager.profile == null)
            return;

        PlayerProfileData p = profileManager.profile;

        string rank = rankSystem != null
            ? rankSystem.GetRank()
            : "BRONZE";

        Debug.Log("===== PROFIL PEMAIN =====");
        Debug.Log("Nama: " + p.playerName);
        Debug.Log("Level: " + p.playerLevel);
        Debug.Log("Rank: " + rank);
        Debug.Log("Total Kill: " + p.totalKills);
        Debug.Log("Pertandingan: " + p.totalMatches);
        Debug.Log("Kemenangan: " + p.totalWins);
    }
}
