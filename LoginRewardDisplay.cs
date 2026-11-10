
using UnityEngine;

public class LoginRewardDisplay : MonoBehaviour
{
    public DailyLoginReward loginReward;

    public void ClaimButton()
    {
        if (loginReward == null)
            return;

        if (loginReward.ClaimReward())
        {
            Debug.Log("Selamat! Hadiah harian diterima.");
        }
        else
        {
            Debug.Log("Hadiah hari ini sudah diklaim.");
        }
    }

    public void ShowReward()
    {
        if (loginReward == null)
            return;

        Debug.Log(
            "Hadiah hari ini: " +
            loginReward.GetTodayReward() + " koin"
        );
    }
}
