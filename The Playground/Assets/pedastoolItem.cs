using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedastoolItem : MonoBehaviour
{
    public float time, test;
    public int item_presented;
    public GameObject[] weapons;
    public GameObject upDown;
    public bool player_in_room, itemCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            player_in_room = true;
            weapons = GameObject.FindGameObjectsWithTag("weapon");
        }
    }

    private void Update()
    {
        itemCollected = upDown.GetComponent<Item_Collection>().done;


        if(player_in_room && itemCollected)
        {
            if(test == 1)
            {
                weapons[0].transform.position = upDown.transform.position;
                weapons[0].transform.parent = upDown.transform;
            }
            else
            {
                time += Time.deltaTime;
                if(time >= 1)
                {
                    time = 0;
                    item_presented += 1;
                }
                if(item_presented > weapons.Length - 1)
                {
                    item_presented = 0;
                }

                if(time > 0.1)
                {
                    weapons[item_presented].transform.position = upDown.transform.position;
                    weapons[item_presented].transform.parent = upDown.transform;
                }

                if(item_presented == 0)
                {
                    weapons[weapons.Length - 1].transform.position = new Vector3(0, 0, 0);
                    weapons[weapons.Length - 1].transform.parent = null;
                }
                else
                {
                    weapons[item_presented - 1].transform.position = new Vector3(0, 0, 0);
                    weapons[item_presented - 1].transform.parent = null;
                }
            }
           
        }
    }
}
