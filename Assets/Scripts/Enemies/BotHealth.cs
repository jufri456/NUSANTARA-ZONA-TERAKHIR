using UnityEngine;

public class BotHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead || damage <= 0f)
            return;

        currentHealth -= damage;

        Debug.Log("HP Bot: " + currentHealth);

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        Debug.Log("Bot berhasil dikalahkan!");

        Destroy(gameObject);
    }
}
