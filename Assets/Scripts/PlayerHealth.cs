using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Set the max health
    public int currentHealth; // Current health
    public HealthBar healthBar; // Reference to the HealthBar script

    void Start()
    {
        currentHealth = maxHealth; // sets current health on start to max health player has
    }

    public void TakeDamage(float damage)
    {
        currentHealth = (int)Mathf.Max(currentHealth - damage, 0); // Reduce current health by the damage amount

        // Check if healthBar is assigned before using it
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth); // Update the health bar 
        }

        if (currentHealth <= 0)
        {
            Die(); // calls die method
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
        SceneManager.LoadScene("GameOver");
    }
}
