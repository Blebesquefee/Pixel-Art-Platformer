using UnityEngine;

public class Weakspot_Script : MonoBehaviour
{
    // Public Field
    public GameObject toDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Destroy(toDestroy);
    }
}
