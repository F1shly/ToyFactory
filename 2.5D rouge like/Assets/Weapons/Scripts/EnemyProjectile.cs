using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public int DMG;

    Rigidbody rb;
    GameObject player;
    Player_Managment player_Managment;
    private bool bol;
    private void Awake()
    {
        transform.parent = null;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_Managment = player.GetComponent<Player_Managment>();
        bol = true;
    }
    void Update()
    {
        rb.velocity = transform.forward * projectileSpeed;
    }
    private void OnCollisionStay(Collision collision)
    {        
        if(collision.gameObject.tag == "Player")
        {
            if(bol)
            {            
                PlayerHit();
                bol = false;
            }
        }
        Destroy(gameObject);
    }
    private void PlayerHit()
    {
        player_Managment.HP -= DMG;
        bol = true;
    }
}
