using UnityEngine;
using UnityEngine.UI;

public class SafeZonePhase : MonoBehaviour
{
    public SafeZoneController zoneController;
    public Text phaseText;
    public Text timerText;

    public float[] phaseRadii =
    {
        400f, 300f, 200f, 120f, 60f, 20f
    };

    public float waitBetweenPhases = 30f;
    public float shrinkDuration = 60f;

    private int currentPhase = 0;
    private float timer;
    private float startRadius;
    private float targetRadius;
    private bool shrinking;

    private void Start()
    {
        if (zoneController == null)
            return;

        if (phaseRadii == null || phaseRadii.Length == 0)
            return;

        startRadius = zoneController.CurrentRadius;
        targetRadius = phaseRadii[0];
    }

    private void Update()
    {
        if (zoneController == null ||
            phaseRadii == null ||
            phaseRadii.Length == 0)
            return;

        timer += Time.deltaTime;

        if (!shrinking && timer >= waitBetweenPhases)
        {
            shrinking = true;
            timer = 0f;

            startRadius = zoneController.CurrentRadius;
            targetRadius = phaseRadii[
                Mathf.Min(currentPhase, phaseRadii.Length - 1)
            ];
        }

        if (shrinking)
        {
            float progress = Mathf.Clamp01(
                timer / shrinkDuration
            );

            float radius = Mathf.Lerp(
                startRadius,
                targetRadius,
                progress
            );

            zoneController.SetRadius(radius);

            if (progress >= 1f)
            {
                shrinking = false;
                currentPhase++;
                timer = 0f;
            }
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (phaseText != null)
        {
            phaseText.text =
                "FASE ZONA: " + (currentPhase + 1);
        }

        if (timerText != null)
        {
            float remaining = shrinking
                ? shrinkDuration - timer
                : waitBetweenPhases - timer;

            timerText.text =
                Mathf.CeilToInt(Mathf.Max(0f, remaining))
                + " DETIK";
        }
    }
}
