using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRoom : MonoBehaviour
{
    public GameObject[] obj;
    public int y = 50, z = -70, x = -70;

    private void Start()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(x - x,y,z), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(0, 70)), y, Mathf.Round(Random.Range(0, 45)) + z), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(-70, -10)), y, Mathf.Round(Random.Range(25, 65)) + z), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(Mathf.Round(Random.Range(-35, 50)), y, Mathf.Round(Random.Range(65, 85)) + z), gameObject.transform.rotation);
        Instantiate(obj[Random.Range(0, obj.Length)], new Vector3(x - x,y,-z), gameObject.transform.rotation);
    }
}
