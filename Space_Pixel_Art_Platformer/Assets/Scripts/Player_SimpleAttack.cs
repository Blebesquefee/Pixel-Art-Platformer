using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SimpleAttack : MonoBehaviour
{
    //Private Part
    private int damage = 25;
    private KeyCode simpleAttackKey = KeyCode.W;

    //Public Part
    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(simpleAttackKey))
            animator.Play("simpleAttack");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("we enter in collision");

        if (collision.transform.CompareTag("Enemy") && Input.GetKeyDown(simpleAttackKey))
        {
            Debug.Log("Its an ennemy");
            Enemy_Health tmp = collision.transform.GetComponent<Enemy_Health>();
            tmp.TakeDamage(damage);
        }

    }

    public void AddPower(int value)
    {
        damage += value;
    }
}
