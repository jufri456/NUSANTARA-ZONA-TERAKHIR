using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Pengaturan HP")]
    public float maxHealth = 100f;
    public float currentHealth;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead || damage <= 0f)
            return;

        currentHealth = Mathf.Clamp(
            currentHealth - damage, 0f, maxHealth
        );

        Debug.Log("HP pemain: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead || amount <= 0f)
            return;

        currentHealth = Mathf.Clamp(
            currentHealth + amount, 0f, maxHealth
        );

        Debug.Log("HP setelah penyembuhan: " + currentHealth);
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Pemain kalah!");
    }
}
