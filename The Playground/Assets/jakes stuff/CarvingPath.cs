using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarvingPath : MonoBehaviour
{
    public GameObject pather;
    private void Awake()
    {
        pather = GameObject.FindGameObjectWithTag("Pather");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == pather.GetComponent<Collider>())
        {
            Destroy(gameObject);
        }
    }
}
