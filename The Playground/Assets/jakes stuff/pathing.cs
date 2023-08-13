using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathing : MonoBehaviour
{
    public GameObject start, end;
    public float speed;
    float curved_speed;
    public bool curve;
    
    private void Awake()
    {
        transform.position = start.transform.position;
    }
    private void Update()
    {
        if(curve)
        {
            curved_speed += Time.deltaTime;
            transform.position = Vector3.Slerp(start.transform.position, end.transform.position, curved_speed / speed);
        }
        else
        {
            float step = speed + Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, step / 5);
        }
    }
}
