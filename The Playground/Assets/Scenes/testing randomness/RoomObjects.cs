using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObjects : MonoBehaviour
{
    public GameObject[] obj;
    private void Awake()
    {
        int a;
        Instantiate(obj[a =Random.Range(0, obj.Length)], new Vector3(transform.position.x + 7, transform.position.y + 2, transform.position.z - 6), obj[a].transform.rotation);
        int b;
        Instantiate(obj[b = Random.Range(0, obj.Length)], new Vector3(transform.position.x - 6, transform.position.y + 2, transform.position.z + 5), obj[b].transform.rotation);
        int c;
        Instantiate(obj[c = Random.Range(0, obj.Length)], new Vector3(transform.position.x - 7, transform.position.y + 2, transform.position.z - 8), obj[c].transform.rotation);
    }
}
