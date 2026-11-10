
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public Camera playerCamera;

    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 0.3f;

    private float nextFireTime = 0f;

    public void Shoot()
    {
        if (Time.time < nextFireTime)
            return;

        nextFireTime = Time.time + fireRate;

        Ray ray = playerCamera.ScreenPointToRay(
            new Vector3(
                Screen.width / 2,
                Screen.height / 2,
                0
            )
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("Tembakan mengenai: " + hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
