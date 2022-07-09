using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Capacity : MonoBehaviour
{
    // Private Field
    private bool ability;
    private bool isInvisible;
    private float coolTime = 15;
    private float coolAbility = 5;

    // Public Field
    public KeyCode capacityKey;
    public Player_CapacityBar capacityBar;
    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        ability = false;
        isInvisible = false;
        capacityBar.Reset(0, coolTime);
    }

    // Update is called once per frame
    void Update()
    {
        Capacity();
    }

    void Capacity()
    {
        if (Input.GetKeyDown(capacityKey) && ability)
        {
            ability = false;
            isInvisible = true;
            sprite.color = new Color(1, 1, 1, (float)0.5);
        }

        if (isInvisible)
        {
            coolAbility -= 1 / coolAbility * Time.deltaTime * 10;
            capacityBar.SetValue(coolAbility);

            if (coolAbility <= 0)
            {
                sprite.color = new Color(1, 1, 1, 1);
                ability = false;
                isInvisible = false;
                coolAbility = 5;
                capacityBar.Reset(0, coolTime);
            }
        }

        if (!isInvisible && !ability)
        {
            coolTime -= 1 / coolTime * Time.deltaTime * 10;
            capacityBar.SetValue(coolTime);

            if (coolTime <= 0)
            {
                ability = true;
                coolTime = 15;
                capacityBar.Reset(0, coolAbility);

            }
        }
    }

    public bool GetInvisibility()
    {
        return isInvisible;
    }
}
