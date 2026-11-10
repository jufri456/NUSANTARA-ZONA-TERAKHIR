
using UnityEngine;

public class PlayerProfileManager : MonoBehaviour
{
    private const string PROFILE_KEY = "NUSANTARA_PROFILE";

    public PlayerProfileData profile;

    private void Awake()
    {
        LoadProfile();
    }

    public void SetPlayerName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            return;

        profile.playerName = newName.Trim();
        SaveProfile();
    }

    public void AddKill()
    {
        profile.totalKills++;
        SaveProfile();
    }

    public void AddMatch()
    {
        profile.totalMatches++;
        SaveProfile();
    }

    public void AddWin()
    {
        profile.totalWins++;
        SaveProfile();
    }

    public void AddLevel()
    {
        profile.playerLevel++;
        SaveProfile();
    }

    public void SaveProfile()
    {
        string json = JsonUtility.ToJson(profile);

        PlayerPrefs.SetString(PROFILE_KEY, json);
        PlayerPrefs.Save();
    }

    public void LoadProfile()
    {
        if (PlayerPrefs.HasKey(PROFILE_KEY))
        {
            string json = PlayerPrefs.GetString(PROFILE_KEY);

            profile = JsonUtility.FromJson<PlayerProfileData>(json);
        }

        if (profile == null)
            profile = new PlayerProfileData();
    }
}
