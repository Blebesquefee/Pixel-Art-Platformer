using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    //Private Part


    //Public Part
    public int health;
    public GameObject enemy;
    public Animator animator;
    public float delay;

    public void TakeDamage(int value)
    {
        health -= value;
        if (health < 0)
        {
            animator.SetBool("death", true);
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
