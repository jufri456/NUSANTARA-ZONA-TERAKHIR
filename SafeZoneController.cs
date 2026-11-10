using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    public Transform safeZone;
    public Transform player;

    public float initialRadius = 500f;
    public float finalRadius = 20f;
    public float shrinkDuration = 180f;
    public float waitBeforeShrink = 30f;

    private float currentRadius;
    private float timer;
    private Vector3 targetCenter;
    private bool shrinking;

    public float CurrentRadius => currentRadius;

    private void Start()
    {
        currentRadius = initialRadius;

        if (safeZone != null)
        {
            safeZone.localScale = new Vector3(
                currentRadius * 2f,
                1f,
                currentRadius * 2f
            );
        }

        targetCenter = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (!shrinking && timer >= waitBeforeShrink)
        {
            shrinking = true;
            timer = 0f;
        }

        if (shrinking)
        {
            ShrinkZone();
        }
    }

    private void ShrinkZone()
    {
        float progress = Mathf.Clamp01(
            timer / shrinkDuration
        );

        currentRadius = Mathf.Lerp(
            initialRadius,
            finalRadius,
            progress
        );

        if (safeZone != null)
        {
            safeZone.localScale = new Vector3(
                currentRadius * 2f,
                1f,
                currentRadius * 2f
            );
        }
    }

    public bool IsInsideSafeZone(Vector3 position)
    {
        Vector2 playerPosition = new Vector2(
            position.x,
            position.z
        );

        Vector2 centerPosition = new Vector2(
            transform.position.x,
            transform.position.z
        );

        return Vector2.Distance(
            playerPosition,
            centerPosition
        ) <= currentRadius;
    }
}
