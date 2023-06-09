using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomClearCheck : MonoBehaviour
{
    public GameObject[] enemy_check;
    public int enemy_total;
    public bool player_in_room, condition_met; //If the condition is finish speaking to NPC or the likes, go into dialogue script, apply the room to a game obj there and make this condiditon true upon finishing dialogue
    public GameObject[] room_walls;

    private void Awake()
    {
        foreach (var item in room_walls)
        {
            item.SetActive(false);
        }
        enemy_total = enemy_check.Length;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            player_in_room = true;
        }
    }
    private void Update()
    {
        if(player_in_room)
        {
            foreach (var item in room_walls)
            {
                item.SetActive(true);
            }
        }
        if(enemy_total <= 0)
        {
            condition_met = true;
        }

        if(condition_met)
        {
            foreach (var item in room_walls)
            {
                Destroy(item);
            }
        }
    }
}
