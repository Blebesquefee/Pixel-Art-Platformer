using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_SwordAttack : MonoBehaviour
{
    //Private Part
    private int damage = 50;
    private KeyCode swordAttackKey = KeyCode.S;
    private bool candamage = false;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && candamage)
        {
            Enemy_Health tmp = other.transform.GetComponent<Enemy_Health>();
            tmp.TakeDamage(damage);
            candamage = false;
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
            candamage = true;
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
