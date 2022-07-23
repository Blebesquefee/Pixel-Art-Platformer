using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_ApplyDifficulty : MonoBehaviour
{
    private GameObject[] chests;
    //Private Part
    private Player_Capacity plcapa;
    private Player_Mvmt plmvnt;
    private Chest_Managment chmgm;
    private Enemy_Health enmh;
    private Enemy_Patrol enmp;

    //Public Part
    public int lvldif;
    public GameObject player;


    // Start is called before the first frame update
    void Awake()
    {
        plcapa = player.GetComponent<Player_Capacity>();
        plmvnt = player.GetComponent<Player_Mvmt>();
        chests = GameObject.FindGameObjectsWithTag("Chest");

        switch (lvldif)
        {
            case 1:
                InitializeLevel(5f, 30f, 2, 250);
                break;
            case 2:
                InitializeLevel(5f, 30f, 2, 250);
                break;
            case 3:
                InitializeLevel(4f, 15f, 2, 125);
                break;
            case 4:
                InitializeLevel(4f, 15f, 2, 125);
                break;
            default:
                InitializeLevel(3f, 15f, 1.5, 60);
                break;
        }
    }


    void InitializeLevel(float coolAbility, float powdelay, double pow, int life)
    {
        plcapa.SetCoolAbility(coolAbility);
        plmvnt.SetPowDelay(powdelay);

        foreach (GameObject chest in chests)
        {
            chmgm = chest.GetComponent<Chest_Managment>();
            chmgm.SetPow(pow);
            chmgm.SetLife(life);
        }
    }
}
