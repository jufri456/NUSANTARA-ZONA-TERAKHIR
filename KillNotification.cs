
using UnityEngine;

public class KillNotification : MonoBehaviour
{
    public GameNotification notification;
    public KillTracker killTracker;

    public void OnEnemyKilled(bool headshot)
    {
        if (killTracker != null)
            killTracker.AddKill();

        if (notification != null)
        {
            if (headshot)
                notification.ShowHeadshot();
            else
                notification.ShowKill();
        }
    }
}
