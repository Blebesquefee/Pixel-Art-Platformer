using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Weakspot : MonoBehaviour
{
    // Public Field
    public GameObject toDestroy;
    public Animator animator;
    public float delay;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.CompareTag("PlayerAttack"))
        {
            animator.SetBool("death", true);
            StartCoroutine(Death());
        }
    }


    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(toDestroy);
    }
}
