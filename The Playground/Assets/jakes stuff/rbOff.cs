using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbOff : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Floor"))
        {
            Destroy(gameObject.GetComponent<Rigidbody>());
        }
        else if(collision.gameObject.tag != ("GridPart"))
        {
            Destroy(gameObject);
        }
    }
}
