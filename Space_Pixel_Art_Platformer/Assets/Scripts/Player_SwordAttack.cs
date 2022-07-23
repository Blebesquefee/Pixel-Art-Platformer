using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_SwordAttack : MonoBehaviour
{
    //Private Part
    private double damage = 50;
    private float powdelay = 0;
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

    public void AddPower(double value)
    {
        double tmp = this.damage;
        this.damage *= value;
        StartCoroutine(BonusDamage());
        this.damage = tmp;
    }
    public void SetPowDelay(float delay) { this.powdelay = delay; }

    IEnumerator BonusDamage() { yield return new WaitForSecondsRealtime(powdelay); }

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
