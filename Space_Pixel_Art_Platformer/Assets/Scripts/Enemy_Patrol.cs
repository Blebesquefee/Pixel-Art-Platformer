using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Patrol : MonoBehaviour
{
    // Private Field
    private Transform target;
    private int destpoint = 0;
    private bool dealdamage;

    // Public Field
    public float moveSpeed = 1;
    public int damage;
    public Transform[] waypoints;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[1];
        dealdamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        // if arrive to destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destpoint = (destpoint + 1) % waypoints.Length;
            target = waypoints[destpoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && dealdamage)
        {
            dealdamage = false;
            Player_Health tmp = collision.transform.GetComponent<Player_Health>();
            tmp.TakeDamage(damage);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        dealdamage = true;
    }
}
