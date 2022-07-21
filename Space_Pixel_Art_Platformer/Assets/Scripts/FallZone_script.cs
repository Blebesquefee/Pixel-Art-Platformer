using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone_script : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Health tmp = collision.transform.GetComponent<Player_Health>();
            tmp.TakeDamage(1000);
        }
    }
}
