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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Input.GetKeyDown(simpleAttackKey))
        {
            Enemy_Health tmp = other.transform.GetComponent<Enemy_Health>();
            tmp.TakeDamage(damage);
        }
    }

    public void AddPower(int value)
    {
        damage += value;
    }
}

