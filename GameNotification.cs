
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameNotification : MonoBehaviour
{
    public Text notificationText;
    public float displayDuration = 3f;

    private Coroutine activeNotification;

    public void ShowMessage(string message)
    {
        if (notificationText == null) return;

        if (activeNotification != null)
            StopCoroutine(activeNotification);

        activeNotification =
            StartCoroutine(DisplayMessage(message));
    }

    private IEnumerator DisplayMessage(string message)
    {
        notificationText.text = message;
        notificationText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        notificationText.gameObject.SetActive(false);
        activeNotification = null;
    }

    public void ShowKill()
    {
        ShowMessage("MUSUH BERHASIL DIKALAHKAN!");
    }

    public void ShowHeadshot()
    {
        ShowMessage("HEADSHOT!");
    }

    public void ShowVictory()
    {
        ShowMessage("BOOYAH! KAMU PEMENANG!");
    }

    public void ShowZoneWarning()
    {
        ShowMessage("PERINGATAN! ZONA AMAN MENGEcil!");
    }
}
