using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    Rigidbody rb;
    GameObject player;
    private void Awake()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = player.transform.rotation;
    }
    void Update()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    private void OnCollisionStay(Collision collision)
    {
        Destroy(gameObject);
    }
}
