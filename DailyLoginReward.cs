
using UnityEngine;
using System;

public class DailyLoginReward : MonoBehaviour
{
    public PlayerWallet wallet;

    public int[] rewards =
    {
        100, 150, 200, 300, 400, 500, 1000
    };

    private const string LAST_LOGIN = "LAST_LOGIN_DATE";
    private const string LOGIN_DAY = "LOGIN_DAY";

    public bool CanClaim()
    {
        string today = DateTime.UtcNow.ToString("yyyyMMdd");

        return PlayerPrefs.GetString(LAST_LOGIN, "") != today;
    }

    public int GetCurrentDay()
    {
        return PlayerPrefs.GetInt(LOGIN_DAY, 0);
    }

    public bool ClaimReward()
    {
        if (wallet == null || !CanClaim())
            return false;

        int day = GetCurrentDay();

        if (day < 0 || day >= rewards.Length)
            day = 0;

        wallet.AddCoins(rewards[day]);

        PlayerPrefs.SetString(
            LAST_LOGIN,
            DateTime.UtcNow.ToString("yyyyMMdd")
        );

        PlayerPrefs.SetInt(
            LOGIN_DAY,
            (day + 1) % rewards.Length
        );

        PlayerPrefs.Save();

        Debug.Log("Hadiah login hari ke-" + (day + 1) +
                  " berhasil diklaim!");

        return true;
    }

    public int GetTodayReward()
    {
        int day = GetCurrentDay();

        if (day < 0 || day >= rewards.Length)
            day = 0;

        return rewards[day];
    }
}
