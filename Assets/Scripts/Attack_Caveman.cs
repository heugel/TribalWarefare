using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Caveman : MonoBehaviour {

    private Attack2 AtkMain;
    private Item item = Item.club;
    private bool hasraw = false;
    private bool hasmeat = false;

    public enum Item
    {
        club,
        spear,
        rawmeat,
        meat
    }

    // Use this for initialization
    void Start ()
    {
        //AtkMain = transform.FindChild("Hitboxes").GetComponent<Attack2>();
        AtkMain = GetComponent<Attack2>();
    }

    // Update is called once per frame
    void Update ()
    {
        //float gofor = Input.GetAxis("Mouse ScrollWheel");
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log(item);
            switch(item)
            {
                case Item.club:
                    item = Item.spear;
                    break;
                case Item.spear:
                    if (hasmeat)
                    {
                        item = Item.meat;
                    }
                    else if (hasraw)
                    {
                        item = Item.rawmeat;
                    }
                    else
                    {
                        item = Item.club;
                    }
                    break;
                case Item.rawmeat:
                    item = Item.club;
                    break;
                case Item.meat:
                    item = Item.club;
                    break;
                default:
                    break;

            }
            //Debug.Log(item);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && item == Item.club)
        {
            if (!AtkMain.isSwinging())
            {
                AtkMain.LaunchAttack(Attack2.AtkType.swing);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && item == Item.club)
        {
            if (!AtkMain.isSwinging())
            {
                AtkMain.LaunchAttack(Attack2.AtkType.block);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && item == Item.spear)
        {
            if (!AtkMain.isSwinging())
            {
                AtkMain.LaunchAttack(Attack2.AtkType.spthrow);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && item == Item.spear)
        {
            if (!AtkMain.isSwinging())
            {
                AtkMain.LaunchAttack(Attack2.AtkType.spstab);
            }
        }
    }
}
