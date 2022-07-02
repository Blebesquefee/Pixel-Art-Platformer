using UnityEngine;
using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

public class CameraFollow : MonoBehaviour
{
    // Private Field
    private float timeOffset = 0.2f;
    private Vector3 posOffset = new Vector3(6.0f, 2.0f, -10.0f);
    private Vector3 velocity;

    // Public Field
    public GameObject player;

    void Start()
    {
        /*
        //Azure Part

        var client = new SecretClient(vaultUri: new Uri("https://keyvaultpixelartproject.vault.azure.net/"),
        credential: new VisualStudioCodeCredential());

        var secret = client.GetSecret("KeyVaultPixelArtProject");

        if (secret != null)
            Debug.Log("Hello Arthur");

        //End Azure Part
        */
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
