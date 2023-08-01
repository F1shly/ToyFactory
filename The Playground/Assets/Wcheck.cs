using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wcheck : MonoBehaviour
{
    public GameObject parent;
    pedastoolItem peda;

    private void Awake()
    {
        peda = parent.GetComponent<pedastoolItem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            peda.test = peda.weapons.Length;
            Destroy(gameObject);
        }
    }
}
