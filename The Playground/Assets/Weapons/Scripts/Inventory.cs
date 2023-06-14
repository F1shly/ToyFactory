using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    GameObject player;
    Inputs inputs;

    public Sprite[] weaponUI;
    public GameObject[] weapon;
    public Image inv_slot_1, inv_slot_2;
    public static int slot1, slot2, slot_Discarded;
    public int test, test2, test3;

    public Transform hand, holster;

    public static bool slot_Active;

    private void Awake()
    {
        slot_Active = true;
        player = GameObject.FindGameObjectWithTag("Player");
        inputs = player.GetComponent<Inputs>();
        hand = GameObject.FindGameObjectWithTag("ItemHolder").transform;
        holster = GameObject.FindGameObjectWithTag("Holster").transform;
    }

    private void Update()
    {
        test = slot1;
        test2 = slot2;
        test3 = slot_Discarded;
        ///cycle through items
        if(inputs.inventSlot == 1)
        {
            slot_Active = true;
        }
        if(inputs.inventSlot == 2)
        {
            slot_Active = false;
        }
        if(inputs.inventSlot > 2)
        {
            inputs.inventSlot = 1;
        }

        ///unpdating active item
        if (slot_Active)
        {
            inv_slot_1.transform.localScale = new Vector3(1, 1, 1);
            inv_slot_2.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

            weapon[slot1].transform.position = hand.position;
            weapon[slot1].transform.rotation = hand.rotation;

            weapon[slot2].transform.position = holster.position;
            weapon[slot2].transform.rotation = holster.rotation;
        }
        if (!slot_Active)
        {
            inv_slot_2.transform.localScale = new Vector3(1, 1, 1);
            inv_slot_1.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

            weapon[slot2].transform.position = hand.position;
            weapon[slot2].transform.rotation = hand.rotation;

            weapon[slot1].transform.position = holster.position;
            weapon[slot1].transform.rotation = holster.rotation;
        }

        weapon[slot1].GetComponent<WeaponPickUp>().onFloor = false;
        weapon[slot2].GetComponent<WeaponPickUp>().onFloor = false;
    }
    private void LateUpdate()
    {
        ///Updating UI
        if(weaponUI[slot1] == null)
        {
            inv_slot_1.enabled = false;
        }
        else
        {
            inv_slot_1.enabled = true;
            inv_slot_1.sprite = weaponUI[slot1];
        }
        if (weaponUI[slot2] == null)
        {
            inv_slot_2.enabled = false;
        }
        else
        {
            inv_slot_2.enabled = true;
            inv_slot_2.sprite = weaponUI[slot2];
        }
    }
}
