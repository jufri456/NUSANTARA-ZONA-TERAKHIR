
using UnityEngine;

public class VehicleHealth : MonoBehaviour
{
    public float maxHealth = 500f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        Debug.Log("Darah kendaraan: " +
            currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            Debug.Log("Kendaraan hancur!");
        }
    }
}
