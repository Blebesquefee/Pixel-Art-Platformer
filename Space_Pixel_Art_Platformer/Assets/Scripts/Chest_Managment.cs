using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest_Managment : MonoBehaviour
{
    //Private Part
    private bool isInRange;
    private bool isOpen;
    private double pow = 0;
    private int life = 0;
    private Text interactUI;

    //Public Part
    public KeyCode interactionKey;
    public Animator chestAnimator;
    public GameObject Coin;
    public Animator coinAnimator;
    public GameObject Heart;
    public Animator heartAnimator;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        interactUI.enabled = false;
        isOpen = false;
        Heart.SetActive(false);
        Coin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactionKey) && isInRange)
            OpenChest();
    }

    private void OpenChest()
    {
        chestAnimator.SetTrigger("isOpen");
        isOpen = true;

        System.Random rnd = new System.Random();
        int tmp = rnd.Next(3);
        if (tmp == 0)
        {
            Coin.SetActive(true);
            Player_Mvmt power = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mvmt>();
            power.AddPower(pow);
            coinAnimator.SetTrigger("isCoins");
        }
        else
        {
            Heart.SetActive(true);
            Player_Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
            health.GainHealth(life);
            heartAnimator.SetTrigger("isHeart");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }

    public void SetLife(int value) { this.life = value; }
    public void SetPow(double value) { this.pow = value; }
}
