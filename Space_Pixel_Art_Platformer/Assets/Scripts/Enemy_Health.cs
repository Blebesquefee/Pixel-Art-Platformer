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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int value)
    {
        health -= value;
        if (health < 0)
        {
            //animator.SetBool("death", true);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(enemy);
    }
}
