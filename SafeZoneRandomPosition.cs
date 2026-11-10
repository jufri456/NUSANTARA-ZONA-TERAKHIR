using UnityEngine;

public class SafeZoneRandomPosition : MonoBehaviour
{
    public SafeZoneController zoneController;
    public float movementRange = 100f;

    public Vector3 GetRandomZoneCenter()
    {
        Vector2 randomPoint = Random.insideUnitCircle
            * movementRange;

        return transform.position + new Vector3(
            randomPoint.x,
            0f,
            randomPoint.y
        );
    }

    public void MoveZone()
    {
        if (zoneController == null)
            return;

        Vector3 newCenter = GetRandomZoneCenter();

        zoneController.transform.position = newCenter;
    }
}
