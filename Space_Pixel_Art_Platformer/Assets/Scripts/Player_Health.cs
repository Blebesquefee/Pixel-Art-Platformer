using UnityEngine;

public class Player_Health : MonoBehaviour
{
    // Private Field
    private int maxHealth = 500;
    private int currentHealth;

    // Public Field
    //public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
