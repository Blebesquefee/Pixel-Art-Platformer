using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paradis_Managment : MonoBehaviour
{
     private Text interactUI;
    // Start is called before the first frame update
    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.enabled = true;
            interactUI.text = "Welcome to the Paradis !!!!";
        }
    }
}
