using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_SimpleAttack : MonoBehaviour
{
    //Private Part
    private double damage = 25;
    private float powdelay = 0;
    private KeyCode simpleAttackKey = KeyCode.W;

    //Public Part
    public Animator animator;
    public CapsuleCollider2D collider;

    void Start()
    {
        collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(simpleAttackKey))
            StartCoroutine(DealDamage());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy_Health tmp = other.transform.GetComponent<Enemy_Health>();
            tmp.TakeDamage(damage);
        }
    }

    IEnumerator DealDamage()
    {
            animator.Play("simpleAttack");
            collider.enabled = true;
            yield return new WaitForSecondsRealtime(0.01f);
            collider.enabled = false;
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
}

