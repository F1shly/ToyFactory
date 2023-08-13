using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarvingPath : MonoBehaviour
{
    public GameObject pather;
    public GameObject floor;
    private void Awake()
    {
        pather = GameObject.FindGameObjectWithTag("Pather");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == pather.GetComponent<Collider>())
        {
            Instantiate(floor, new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), transform.rotation);
        }
    }
}
