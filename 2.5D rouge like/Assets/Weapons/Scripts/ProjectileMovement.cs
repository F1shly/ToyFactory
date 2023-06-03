using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed;
    public int DMG;

    public GameObject objHit;

    Rigidbody rb;
    private bool bol;
    private void Awake()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody>();

        bol = true;
        gameObject.tag = "Bullet";
    }
    public void Update()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    private void OnCollisionStay(Collision collision)
    {
        print(collision.collider.name);
        objHit = GameObject.Find(collision.collider.name);
        if (collision.gameObject.tag == "Enemy")
        {
            print(collision.collider.name);
            if (bol)
            {
                TargetHit();
                bol = false;
            }
        }
        if (!(collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
        }
    }
    private void TargetHit()
    {
        objHit.GetComponent<EnemyBehaviour>().HP -= DMG;
        bol = true;
    }
}
