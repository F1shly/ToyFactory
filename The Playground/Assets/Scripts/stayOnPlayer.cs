using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayOnPlayer : MonoBehaviour
{
    Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = player.position;
    }
}
