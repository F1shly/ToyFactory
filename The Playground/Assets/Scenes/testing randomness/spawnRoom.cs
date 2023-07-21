using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{
    public GameObject[] obj;

    private void Start()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)), gameObject.transform.rotation);
    }
}
