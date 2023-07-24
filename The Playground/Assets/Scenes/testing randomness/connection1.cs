using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connection1 : MonoBehaviour
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
    private void LateUpdate()
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
        if (distX * distX > test || distZ * distZ > test)
        {
            if (on)
            {
                on = false;
                //rest of code to spawn stuff in

                Debug.Log("lon");
                //if above
                if (transform.position.x > nextRoom.transform.position.x)
                {
                    if (distX * distX < distZ * distZ)
                    {
                        if (transform.position.z > nextRoom.transform.position.z)
                        {
                            Instantiate(connectors[1], new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z));
                        }
                        else
                        {
                            Instantiate(connectors[1], new Vector3(transform.position.x - 2.5f, transform.position.y, transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z));
                        }
                    }
                    else
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), transform.rotation);
                    }
                }
                //if below
                else
                {
                    if (distX * distX < distZ * distZ)
                    {
                        if (transform.position.z > nextRoom.transform.position.z)
                        {
                            Instantiate(connectors[1], new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90, transform.rotation.z));
                        }
                        else
                        {
                            Instantiate(connectors[1], new Vector3(transform.position.x + 2.5f, transform.position.y, transform.position.z), Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                        }
                    }
                    else
                    {
                        Instantiate(connectors[0], new Vector3(transform.position.x + 5, transform.position.y, transform.position.z), transform.rotation);
                    }
                }
            }
        }
    }
}
