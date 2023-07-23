using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locating : MonoBehaviour
{
    public GameObject[] rooms,connectors;
    bool on = true;
    private void Update()
    {
        rooms = GameObject.FindGameObjectsWithTag("ROOM");
        if(on)
        {
            Instantiate(connectors[0], rooms[0].transform.position, connectors[0].transform.rotation);
            on = false;
        }
    }
}
