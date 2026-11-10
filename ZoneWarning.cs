
using UnityEngine;

public class ZoneWarning : MonoBehaviour
{
    public SafeZoneController safeZone;
    public GameNotification notification;

    private float warningTimer;
    private bool warned;

    public float warningInterval = 10f;

    void Update()
    {
        if (safeZone == null || notification == null)
            return;

        warningTimer += Time.deltaTime;

        if (warningTimer >= warningInterval && !warned)
        {
            notification.ShowZoneWarning();
            warned = true;
        }
    }
}
