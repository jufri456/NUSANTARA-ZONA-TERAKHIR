using UnityEngine;
using UnityEngine.UI;

public class SafeZoneWarning : MonoBehaviour
{
    public SafeZoneController zoneController;
    public Transform player;
    public Text warningText;

    private void Update()
    {
        if (zoneController == null || player == null)
            return;

        bool inside = zoneController.IsInsideSafeZone(
            player.position
        );

        if (warningText != null)
        {
            warningText.text = inside
                ? "KAMU BERADA DI ZONA AMAN"
                : "BAHAYA! KELUAR DARI ZONA AMAN!";
        }
    }
}
