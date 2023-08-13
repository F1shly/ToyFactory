using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public GameObject pather, floor, gridpart;
    public int gridx = 1, gridy = 1;
    

    private void Start()
    {
        for (int i = 0; i < gridx; i++)
        {
            for (int l = 0; l < gridy; l++)
            {
                Instantiate(gridpart, new Vector3(transform.position.x + (i*10),transform.position.y,transform.position.z + (l*10)),transform.rotation);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other == pather.GetComponent<Collider>())
        {
            Instantiate(floor, new Vector3(transform.position.x, transform.position.y + 20, transform.position.z), floor.transform.rotation, floor.transform.parent = transform);
        }
    }
}
