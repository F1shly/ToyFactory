using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public GameObject gridpart;
    public int gridx = 1, gridy = 1;
    public GameObject[] obj, rooms, pathfinders;
    public int y = 20, z = -100, x = -100;

    float wait = 0;

    //have it so that a timer starts once hte player leaves "playable area" - put code in player probably
    private void Start()
    {

        for (int i = 0; i < gridx; i++)
        {
            for (int l = 0; l < gridy; l++)
            {
                Instantiate(gridpart, new Vector3(transform.position.x + (i*10),transform.position.y,transform.position.z + (l*10)),transform.rotation);
            }
        }


        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(-x, y, z), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(10 * Mathf.Round(Random.Range(-10, -3)), y, 10 * Mathf.Round(Random.Range(-10, -3))), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(10 * Mathf.Round(Random.Range(0, 10)), y, 10 * Mathf.Round(Random.Range(-3, 4))), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(10 * Mathf.Round(Random.Range(-10, 0)), y, 10 * Mathf.Round(Random.Range(4, 8))), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(x - x, y, -z), gameObject.transform.rotation);
        rooms = GameObject.FindGameObjectsWithTag("ROOM");
        //individual pathing
        {
            pathfinders[0].GetComponent<pathing>().start = rooms[0];
            pathfinders[0].GetComponent<pathing>().end = rooms[1];
            pathfinders[1].GetComponent<pathing>().start = rooms[1];
            pathfinders[1].GetComponent<pathing>().end = rooms[2];
            pathfinders[2].GetComponent<pathing>().start = rooms[2];
            pathfinders[2].GetComponent<pathing>().end = rooms[3];
            pathfinders[3].GetComponent<pathing>().start = rooms[3];
            pathfinders[3].GetComponent<pathing>().end = rooms[4];
            //pathfinders[4].GetComponent<pathing>().start = rooms[0];
            //pathfinders[4].GetComponent<pathing>().end = rooms[2];
            //pathfinders[5].GetComponent<pathing>().start = rooms[2];
            //pathfinders[5].GetComponent<pathing>().end = rooms[4];
        }
        
    }
}
