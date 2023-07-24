using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{
    public GameObject[] obj;

    private void Start()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(50,0,0), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(50, 100), 0, Random.Range(10, 30)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 60), 0, Random.Range(20, 40)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(20, 80), 0, Random.Range(40, 70)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(50,0,100), gameObject.transform.rotation);
    }
}
