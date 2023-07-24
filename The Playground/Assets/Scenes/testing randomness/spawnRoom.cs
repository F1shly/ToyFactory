using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{
    public GameObject[] obj;

    private void Start()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(50,0,0), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(5, 10)) * 10, 0, Mathf.Round(Random.Range(1, 3)) * 10), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(0, 6)) * 10, 0, Mathf.Round(Random.Range(2, 4)) * 10), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(2, 8)) * 10, 0, Mathf.Round(Random.Range(4, 7)) * 10), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(50,0,100), gameObject.transform.rotation);
    }
}
