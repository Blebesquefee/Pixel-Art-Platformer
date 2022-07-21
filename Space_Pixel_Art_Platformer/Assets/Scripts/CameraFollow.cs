using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    // Private Field
    private float timeOffset = 0.2f;
    private Vector3 posOffset = new Vector3(6.0f, 2.0f, -10.0f);
    private Vector3 velocity;

    // Public Field
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        }
        catch
        {
            Debug.Log("No Player");
        }
    }
}
