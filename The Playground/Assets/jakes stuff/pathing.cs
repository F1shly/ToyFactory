using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathing : MonoBehaviour
{
    public GameObject start, end;
    public float speed = 5;
    
    private void Awake()
    {
        transform.position = start.transform.position;
        
    }
    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, end.transform.position, step);
    }
}
