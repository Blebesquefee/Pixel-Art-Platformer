using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_SwordAttack : MonoBehaviour
{
    //Private Part
    private int damage = 50;
    private KeyCode swordAttackKey = KeyCode.S;

    //Public Part
    public Animator animator;
    public CapsuleCollider2D collider;

    private void Start()
    {
        collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(swordAttackKey))
            StartCoroutine(DealDamage());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Enemy_Health tmp = collision.transform.GetComponent<Enemy_Health>();
            tmp.TakeDamage(damage);
        }
    }

    public void AddPower(int value)
    {
        damage += value;
    }

    IEnumerator DealDamage()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (Input.GetKey(swordAttackKey))
        {
            animator.Play("swordAttack");
            collider.enabled = true;
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.20f);
        collider.enabled = false;
    }
}
