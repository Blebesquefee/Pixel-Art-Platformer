using UnityEngine;

public class Enemy_Weakspot : MonoBehaviour
{
    // Public Field
    public GameObject toDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.CompareTag("PlayerAttack"))
            Destroy(toDestroy);
    }
}
