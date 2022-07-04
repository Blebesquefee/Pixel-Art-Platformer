using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Capacity : MonoBehaviour
{
    private bool ability;
    private float cooldown = 0;
    private float useTime = 5f;
    private float coolTime = 15f;

    public bool isInvisible;

    public CapacityBar capacitybar;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ability = false;
        isInvisible = false;
        capacitybar.Reset(cooldown, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("c") && ability)
        {
            isInvisible = true;
            ability = false;
            capacitybar.Reset(0, useTime);
            StartCoroutine("UseTime");
            capacitybar.Reset(0, coolTime);
            StartCoroutine("CoolDown");
        }
    }

    IEnumerator UseTime()
    {
        cooldown = 0;
        spriteRenderer.color = new Color(1, 1, 1, 0);

        while (true)
        {
            cooldown += Time.deltaTime;
            capacitybar.SetValue(cooldown / useTime);

            if (cooldown >= useTime)
            {
                isInvisible = false;
                StopCoroutine("UseTime");
            }
        }

        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return null;
    }

    IEnumerator CoolDown()
    {
        cooldown = 0;
        while (true)
        {
            cooldown += Time.deltaTime;
            capacitybar.SetValue(cooldown / coolTime);

            if (cooldown >= coolTime)
            {
                ability = true;
                StopCoroutine("CoolDown");
            }
        }
        yield return null;
    }
}
