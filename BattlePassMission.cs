
using UnityEngine;

public class BattlePassMission : MonoBehaviour
{
    public BattlePassManager battlePass;

    public void CompleteMission()
    {
        if (battlePass == null)
        {
            Debug.Log("Battle Pass belum dihubungkan!");
            return;
        }

        battlePass.AddXP(50);

        Debug.Log("Misi selesai! Kamu mendapatkan 50 XP.");
    }

    public void CompleteWinMission()
    {
        if (battlePass == null) return;

        battlePass.AddXP(100);

        Debug.Log("Kemenangan! Kamu mendapatkan 100 XP.");
    }
}
