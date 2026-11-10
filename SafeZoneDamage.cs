using UnityEngine;

public class SafeZoneDamage : MonoBehaviour
{
    public SafeZoneController zoneController;
    public float damagePerSecond = 5f;
    public float damageInterval = 1f;

    private float timer;

    private void Update()
    {
        if (zoneController == null)
            return;

        timer += Time.deltaTime;

        if (timer >= damageInterval)
        {
            timer = 0f;
            CheckZone();
        }
    }

    private void CheckZone()
    {
        bool inside = zoneController.IsInsideSafeZone(
            transform.position
        );

        if (!inside)
        {
            PlayerHealth health =
                GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(
                    damagePerSecond * damageInterval
                );
            }
        }
    }
}
