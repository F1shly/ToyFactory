using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collection : MonoBehaviour
{
    public int itemID;
    private bool up;
    private float timer;
    GameObject player;
    Inventory inventory;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>()) 
        {
            if(Inventory.slot1 == 0)
            {
                Inventory.slot_Active = true;
                Inventory.slot1 = itemID;
            }
            else if(Inventory.slot2 == 0)
            {
                Inventory.slot_Active = false;
                Inventory.slot2 = itemID;
            }
            else if(Inventory.slot_Active)
            {
                Inventory.slot_Discarded = Inventory.slot1;
                Inventory.slot1 = itemID;
            }
            else
            {
                Inventory.slot_Discarded = Inventory.slot2;
                Inventory.slot2 = itemID;
            }
            Destroy(gameObject);

        }
    }

    private void Update()
    {
        if (up)
        {
            transform.position = transform.position + new Vector3(0, Time.deltaTime / 4, 0);
        }
        if (!up)
        {
            transform.position = transform.position + new Vector3(0, -Time.deltaTime / 4, 0);
        }

        timer += Time.deltaTime;
        if (timer <= 2)
        {
            up = true;
        }
        if (timer > 2)
        {
            up = false;
        }
        if (timer >= 4)
        {
            timer = 0;
        }

        transform.eulerAngles = transform.eulerAngles + new Vector3(0, Time.deltaTime * 30, 0);
    }
}
