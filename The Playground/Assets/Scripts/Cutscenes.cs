using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Cutscenes : MonoBehaviour
{
    public float speed;
    public float cutsceneStart = 0;
    public GameObject mainCam;
    public GameObject cutSceneCam;
    public Transform target;
    Transform camOrigin;

    public GameObject MainUI;
    public GameObject NPCUI;

    GameObject player;
    Movement movement;
    private Animator anim;
    public Transform standingspot;

    private void Awake()
    {
        camOrigin = mainCam.transform;
        player = GameObject.FindGameObjectWithTag("Player");
        movement = player.GetComponent<Movement>();
        anim = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            movement.canMove = false;
            anim.SetInteger("Direction", 0);
            player.transform.position = standingspot.position;
            player.transform.rotation = standingspot.rotation;

            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);
            MainUI.SetActive(false);
            NPCUI.SetActive(true);
        }
    }
    private void Update()
    {
        if(cutsceneStart == 1)
        {
            NPCUI.SetActive(false);
            cutSceneCam.transform.LookAt(target);
            var step = speed * Time.deltaTime;
            cutSceneCam.transform.position = Vector3.MoveTowards(cutSceneCam.transform.position, target.position, step);
            if (Vector3.Distance(cutSceneCam.transform.position, target.position) < 15)
            {
                cutsceneStart = 2;
                StartCoroutine(Cutscene());
            }
        }
        if(cutsceneStart == 3)
        {
            var step = speed * Time.deltaTime * 1.5f;
            cutSceneCam.transform.position = Vector3.MoveTowards(cutSceneCam.transform.position, camOrigin.position, step);
            if (Vector3.Distance(cutSceneCam.transform.position, camOrigin.position) < 1)
            {
                cutSceneCam.SetActive(false);
                mainCam.SetActive(true);
                movement.canMove = true;
                MainUI.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(3);
        cutsceneStart += 1;
    }
}
