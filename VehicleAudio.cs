using UnityEngine;

public class VehicleAudio : MonoBehaviour
{
    public AudioSource engineSource;

    public float minPitch = 0.8f;
    public float maxPitch = 2f;

    public float maxSpeed = 100f;

    public void UpdateEngine(float currentSpeed)
    {
        if (engineSource == null)
            return;

        float speedPercent = Mathf.Clamp01(
            currentSpeed / maxSpeed
        );

        engineSource.pitch = Mathf.Lerp(
            minPitch,
            maxPitch,
            speedPercent
        );

        if (currentSpeed > 0.1f && !engineSource.isPlaying)
            engineSource.Play();

        if (currentSpeed <= 0.1f && engineSource.isPlaying)
            engineSource.Stop();
    }
}
