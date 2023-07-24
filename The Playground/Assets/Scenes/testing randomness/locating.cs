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
            Instantiate(connectors[1], rooms[1].transform.position, connectors[1].transform.rotation);
            Instantiate(connectors[2], rooms[2].transform.position, connectors[2].transform.rotation);
            Instantiate(connectors[3], rooms[3].transform.position, connectors[3].transform.rotation);
            Instantiate(connectors[4], rooms[1].transform.position, connectors[4].transform.rotation);


            on = false;
        }
    }
}
