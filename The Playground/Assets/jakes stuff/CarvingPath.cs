using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarvingPath : MonoBehaviour
{
    public GameObject[] pather, rooms;
    public GameObject floor;
    private void Awake()
    {
        pather = GameObject.FindGameObjectsWithTag("Pather");
    }
    private void Update()
    {
        rooms = GameObject.FindGameObjectsWithTag("ROOM");
    }
    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in pather)
        {
            if (other == item.GetComponent<Collider>())
            {
                Instantiate(floor, new Vector3(transform.position.x, transform.position.y + 70, transform.position.z), transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
