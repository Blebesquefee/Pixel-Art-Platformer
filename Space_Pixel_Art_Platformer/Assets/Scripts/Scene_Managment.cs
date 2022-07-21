using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Managment : MonoBehaviour
{
    public void Home() { SceneManager.LoadScene(0); }
    public void LoadLevel1() { SceneManager.LoadScene(1); }
    public void Quit() { Application.Quit(); }
}
