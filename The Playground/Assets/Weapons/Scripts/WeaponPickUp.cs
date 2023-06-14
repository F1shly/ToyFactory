using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public int itemID;
    GameObject player;
    public bool onFloor;
    Inventory inventory;
    public GameObject LevelManager;
    public Vector3 scale;
    private void Start()
    {
        onFloor = true;
    }
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        LevelManager = GameObject.FindGameObjectWithTag("LevelManager");
        inventory = LevelManager.GetComponent<Inventory>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            transform.localScale = scale;
            transform.parent = null;
            if (Inventory.slot1 == 0)
            {
                Inventory.slot_Active = true;
                Inventory.slot1 = itemID;
            }
            else if (Inventory.slot2 == 0)
            {
                Inventory.slot_Active = false;
                Inventory.slot2 = itemID;
            }
            else if (Inventory.slot_Active)
            {
                Inventory.slot_Discarded = Inventory.slot1;
                Inventory.slot1 = itemID;
                StartCoroutine(waiting());
            }
            else
            {
                Inventory.slot_Discarded = Inventory.slot2;
                Inventory.slot2 = itemID;
                StartCoroutine(waiting());
            }
        }
    }
    IEnumerator waiting()
    {
        yield return new WaitForSeconds(1);
        inventory.weapon[Inventory.slot_Discarded].GetComponent<WeaponPickUp>().onFloor = true;
    }

    private void Update()
    {
        if(onFloor)
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
        if(!onFloor)
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
