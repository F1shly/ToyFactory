using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public LayerMask playerMask;
    //public Transform playerCheck;
    //public Transform selfTransform;
    //public float areaRadius;
    GameObject player;
    NavMeshAgent agent;

    public float HP;

    //float timer;

    //public float test;

    [SerializeField] public Renderer myModelHead;
    [SerializeField] public Renderer myModelBody;
    [SerializeField] public Renderer myModelLegs;
    public Material defaultMat;
    public Material damageMat;
    public float delay = 0.5f;

    public bool hasBeenAttacked = false;

    public GameObject assignedRoom;
    RoomClearCheck roomClearCheck;

    //new
    public float sightRange;
    public float attackRange;
    public bool playerInSightRange;
    public bool playerInAttackRange;

    public Vector3 movePoint;
    bool movePointSet;
    public float movePointRange;

    public LayerMask groundMask;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        roomClearCheck = assignedRoom.GetComponent<RoomClearCheck>();
    }
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
            //Debug.Log("patrol");
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            //Debug.Log("chase");
        }
        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
            //Debug.Log("attack");
        }

        /*
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
        */

        if(HP <= 0)
        {
            Destroy(gameObject);
        }

        if(hasBeenAttacked)
        {
            EnemyHit();
        }
    }

    private void Patrolling()
    {
        gameObject.GetComponent<EnemyShootyShoot>().enabled = false;

        if (!movePointSet)
        {
            SearchMovePoint();
        }

        if (movePointSet)
        {
            agent.destination = movePoint;
        }

        Vector3 distanceToMovePoint = transform.position - movePoint;

        if (distanceToMovePoint.magnitude < 1f)
        {
            movePointSet = false;
        }
    }
    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
        gameObject.GetComponent<EnemyShootyShoot>().enabled = false;
    }

    private void AttackPlayer()
    {
        agent.destination = transform.position;
        transform.LookAt(player.transform);

        //Attack code here
        gameObject.GetComponent<EnemyShootyShoot>().enabled = true;
    }

    private void SearchMovePoint()
    {
        float randomZ = Random.Range(-movePointRange, movePointRange);
        float randomX = Random.Range(-movePointRange, movePointRange);

        movePoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(movePoint, -transform.up, 2f, groundMask))
        {
            movePointSet = true;
        }
    }

    void EnemyHit()
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
            delay = 0.5f;
            hasBeenAttacked = false;
        }
    }



    private void OnDestroy()
    {
        roomClearCheck.enemy_total -= 1;
    }
}
