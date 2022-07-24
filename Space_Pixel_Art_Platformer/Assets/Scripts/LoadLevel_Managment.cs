using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel_Managment : MonoBehaviour
{
    //Public Part
    public int iLevelToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collision = other.gameObject;
        if (collision.transform.CompareTag("Player"))
            LoadLevel();
    }

    void LoadLevel(){SceneManager.LoadScene(iLevelToLoad);}
}
