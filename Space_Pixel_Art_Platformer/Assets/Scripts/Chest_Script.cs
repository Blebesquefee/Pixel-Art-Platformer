using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest_Script : MonoBehaviour
{
    //Private Part
    private bool isInRange;
    private bool isOpen;
    private bool coin;
    private bool hearth;
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
        int tmp = rnd.Next(2);
        if (tmp == 0)
        {
            Heart.SetActive(true);
            Player_Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
            health.GainHealth(100);
            heartAnimator.SetTrigger("isHeart");
        }
        else
        {
            Coin.SetActive(true);
            Player_Mvmt power = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mvmt>();
            power.AddPower(25);
            coinAnimator.SetTrigger("isCoins");
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
}
