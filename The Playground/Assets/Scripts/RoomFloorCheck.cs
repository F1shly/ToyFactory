using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomFloorCheck : MonoBehaviour
{
    //attatch this to objects in room with colliders (make sure they are children to the room)
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<Collider>().tag == "Player")
        {
            transform.parent.GetComponent<RoomClearCheck>().player_in_room = true;
            print("nodanca");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //transform.parent.GetComponent<RoomClearCheck>().player_in_room = false;
        }
    }
}
