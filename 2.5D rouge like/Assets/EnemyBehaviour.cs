using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public LayerMask playerMask;
    public Transform playerCheck;
    public Transform selfTransform;
    public float areaRadius, tooClose;
    GameObject player;
    NavMeshAgent agent;

    public float HP;

    float timer;

    public float test;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            if (Physics.CheckSphere(playerCheck.position, areaRadius, playerMask) &! Physics.CheckSphere(playerCheck.position, tooClose, playerMask))
            {
                gameObject.GetComponent<EnemyShootyShoot>().enabled = false;
                agent.destination = player.transform.position;
            }
            if (Physics.CheckSphere(playerCheck.position, tooClose, playerMask))
            {
                gameObject.GetComponent<EnemyShootyShoot>().enabled = true;
                agent.destination = transform.position;
                transform.LookAt(player.transform);
            }
            if (!Physics.CheckSphere(playerCheck.position, areaRadius, playerMask))
            {
                gameObject.GetComponent<EnemyShootyShoot>().enabled = false;
                agent.destination = transform.position;
            }
        }
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
