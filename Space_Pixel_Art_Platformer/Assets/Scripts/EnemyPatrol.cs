using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    private float moveSpeed = 3;
    private Transform target;
    private int destpoint = 0;

    // Public Field
    public Transform[] waypoints;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[1];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destpoint = (destpoint + 1) % waypoints.Length;
            target = waypoints[destpoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
