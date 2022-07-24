using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    //Private Part

    //Public Part
    public GameObject enemy;
    public Animator animator;
    public float delay;
    public double health;

    public void TakeDamage(double value)
    {
        health -= value;
        if (health < 0)
        {
            animator.SetBool("death", true);
            Collider2D other = enemy.GetComponent<Collider2D>();
            other.enabled = false;
            StartCoroutine(Death());
        }
        else
            animator.Play("hit");
    }

    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(enemy);
    }
}
