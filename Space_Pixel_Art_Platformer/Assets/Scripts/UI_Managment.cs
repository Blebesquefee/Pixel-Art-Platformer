using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Managment : MonoBehaviour
{
    //Public Part
    public GameObject playerCanva;

    // Start is called before the first frame update
    void Start()
    {
        playerCanva.transform.GetChild(3).gameObject.SetActive(false); // SetActive false PauseUI
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPause()
    {
        Time.timeScale = 0f;
        playerCanva.transform.GetChild(3).gameObject.SetActive(true); // SetActive true PauseUI
    }

    public void ExitPause()
    {
        Time.timeScale = 1f;
        playerCanva.transform.GetChild(3).gameObject.SetActive(false); // SetActive false PauseUI
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
