
using UnityEngine;
using UnityEngine.UI;

public class RemainingPlayers : MonoBehaviour
{
    public Text playerCountText;

    public int totalPlayers = 100;
    private int eliminatedPlayers = 0;

    public int GetRemainingPlayers()
    {
        return Mathf.Max(0, totalPlayers - eliminatedPlayers);
    }

    public void EliminatePlayer()
    {
        if (eliminatedPlayers >= totalPlayers)
            return;

        eliminatedPlayers++;

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (playerCountText != null)
        {
            playerCountText.text =
                "Pemain tersisa: " + GetRemainingPlayers();
        }
    }

    private void Start()
    {
        UpdateDisplay();
    }
}
