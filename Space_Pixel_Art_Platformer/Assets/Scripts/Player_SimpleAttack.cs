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

