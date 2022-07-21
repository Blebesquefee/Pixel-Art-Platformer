using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    // Private Field
    private int maxHealth = 250;
    private Player_Capacity capacity;

    // Public Field
    public int currentHealth;
    public Player_HealthBar healthBar;
    public GameObject hero;
    public Animator animator;

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
        if (currentHealth > 250)
            currentHealth = 250;
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (!capacity.GetInvisibility())
        {
            currentHealth -= damage;
            if (currentHealth > 0)
            {
                animator.Play("hit", 0, 0);
                healthBar.SetHealth(currentHealth);
            }
            else
            {
                animator.SetBool("death", true);
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(1);
        Destroy(hero);
        SceneManager.LoadScene(0);
    }
}
