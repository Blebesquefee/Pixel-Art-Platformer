using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Private Field
    private int maxHealth = 250;
    private bool isInvincible = false;

    // Public Field
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
