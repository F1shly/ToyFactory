using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerCon1 : MonoBehaviour
{
    public int test, roomint;
    public bool on = true;
    locating Locating;
    public GameObject[] connectors;
    //find next rooom based on room this is attached to - spwan this in with each new room - transform.getParent stuff
    public GameObject nextRoom;

    private void Awake()
    {
        on = true;
    }
    private void Update()
    {
        Locating = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<locating>();
        nextRoom = Locating.rooms[roomint];

        float distX = nextRoom.transform.position.x - transform.position.x;
        float distZ = nextRoom.transform.position.z - transform.position.z;


        if (distX * distX < test && distZ * distZ < test)
        {
            on = false;
            Debug.Log("shor");
        }
        else
        {
            if(on)
            {
                on = false; 
                if(nextRoom.transform.position.z > transform.position.z)
                {
                    if(nextRoom.transform.position.x > transform.position.x)
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x, transform.position.y, transform.position.z + 2.5f), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x - 2, transform.position.y, transform.position.z + 4.5f), Quaternion.Euler(0, 0, 0));
                    }
                }
                else
                {
                    if (nextRoom.transform.position.x > transform.position.x)
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x + 2, transform.position.y, transform.position.z - 2.5f), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x, transform.position.y, transform.position.z - 4.5f), Quaternion.Euler(0, 0, 0));
                    }
                } 
            }

        }
    }
}
