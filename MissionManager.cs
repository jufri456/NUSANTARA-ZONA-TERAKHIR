
using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public PlayerWallet wallet;
    public BattlePassManager battlePass;

    [Serializable]
    public class MissionProgress
    {
        public string missionId;
        public int progress;
        public bool claimed;
    }

    public List<DailyMission> dailyMissions =
        new List<DailyMission>();

    private const string DATE_KEY = "MISSION_DATE";

    private string Today()
    {
        return DateTime.UtcNow.ToString("yyyyMMdd");
    }

    private void Start()
    {
        ResetDailyMissionsIfNeeded();
    }

    private void ResetDailyMissionsIfNeeded()
    {
        if (PlayerPrefs.GetString(DATE_KEY, "") == Today())
            return;

        foreach (DailyMission mission in dailyMissions)
        {
            PlayerPrefs.SetInt(
                "MISSION_PROGRESS_" + mission.missionId, 0
            );

            PlayerPrefs.SetInt(
                "MISSION_CLAIMED_" + mission.missionId, 0
            );
        }

        PlayerPrefs.SetString(DATE_KEY, Today());
        PlayerPrefs.Save();
    }

    public void AddProgress(string missionId, int amount)
    {
        DailyMission mission = dailyMissions.Find(
            item => item.missionId == missionId
        );

        if (mission == null || amount <= 0)
            return;

        if (IsClaimed(missionId))
            return;

        string key = "MISSION_PROGRESS_" + missionId;

        int progress = PlayerPrefs.GetInt(key, 0);
        progress = Mathf.Min(progress + amount, mission.target);

        PlayerPrefs.SetInt(key, progress);
        PlayerPrefs.Save();

        Debug.Log(mission.missionName + ": " + progress +
                  "/" + mission.target);
    }

    public bool IsCompleted(string missionId)
    {
        DailyMission mission = dailyMissions.Find(
            item => item.missionId == missionId
        );

        if (mission == null) return false;

        return PlayerPrefs.GetInt(
            "MISSION_PROGRESS_" + missionId, 0
        ) >= mission.target;
    }

    public bool IsClaimed(string missionId)
    {
        return PlayerPrefs.GetInt(
            "MISSION_CLAIMED_" + missionId, 0
        ) == 1;
    }

    public bool ClaimReward(string missionId)
    {
        DailyMission mission = dailyMissions.Find(
            item => item.missionId == missionId
        );

        if (mission == null || !IsCompleted(missionId))
            return false;

        if (IsClaimed(missionId))
            return false;

        if (wallet == null || battlePass == null)
            return false;

        wallet.AddCoins(mission.rewardCoins);
        battlePass.AddXP(mission.rewardXP);

        PlayerPrefs.SetInt(
            "MISSION_CLAIMED_" + missionId, 1
        );

        PlayerPrefs.Save();

        Debug.Log("Hadiah misi berhasil diklaim!");
        return true;
    }
}
