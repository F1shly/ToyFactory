using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public LayerMask playerMask;
    public Transform playerCheck;
    public Transform selfTransform;
    public float areaRadius;
    GameObject player;
    NavMeshAgent agent;

    public float HP;

    float timer;

    public float test;

    [SerializeField] public Renderer myModelHead;
    [SerializeField] public Renderer myModelBody;
    [SerializeField] public Renderer myModelLegs;
    public Material defaultMat;
    public Material damageMat;
    public float delay = 0.5f;

    public bool hasAttacked = false;

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
            if (Physics.CheckSphere(playerCheck.position, areaRadius, playerMask))
            {
                gameObject.GetComponent<EnemyShootyShoot>().enabled = true;
                agent.destination = player.transform.position;
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

        if(hasAttacked)
        {
            myModelHead.material = damageMat;
            myModelBody.material = damageMat;
            myModelLegs.material = damageMat;

            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                myModelHead.material = defaultMat;
                myModelBody.material = defaultMat;
                myModelLegs.material = defaultMat;
                Debug.Log("HHHHHHHHH");
                delay = 0.5f;
                hasAttacked = false;
            }
        }
    }
}
