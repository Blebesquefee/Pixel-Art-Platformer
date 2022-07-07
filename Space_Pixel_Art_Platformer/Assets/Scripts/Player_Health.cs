using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Private Field
    private int maxHealth = 250;
    private Player_Capacity capacity;

    // Public Field
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject hero;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        capacity = hero.GetComponent<Player_Capacity>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GainHealth(int value)
    {
        currentHealth += value;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!capacity.GetInvisibility())
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
