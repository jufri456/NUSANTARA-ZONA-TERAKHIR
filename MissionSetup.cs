
using UnityEngine;

public class MissionSetup : MonoBehaviour
{
    public MissionManager missionManager;

    private void Start()
    {
        if (missionManager == null) return;

        missionManager.dailyMissions.Clear();

        missionManager.dailyMissions.Add(new DailyMission
        {
            missionId = "KILL_5",
            missionName = "Kalahkan 5 musuh",
            target = 5,
            rewardCoins = 100,
            rewardXP = 50
        });

        missionManager.dailyMissions.Add(new DailyMission
        {
            missionId = "PLAY_1",
            missionName = "Selesaikan 1 pertandingan",
            target = 1,
            rewardCoins = 150,
            rewardXP = 75
        });

        missionManager.dailyMissions.Add(new DailyMission
        {
            missionId = "SURVIVE_10",
            missionName = "Bertahan selama 10 menit",
            target = 10,
            rewardCoins = 200,
            rewardXP = 100
        });
    }
}
