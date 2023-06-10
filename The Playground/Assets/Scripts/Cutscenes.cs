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

    public TextMeshProUGUI NPCText;
    public GameObject MainUI;
    public GameObject NPCUI;

    public GameObject pSystems;

    private void Awake()
    {
        camOrigin = mainCam.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            StartCoroutine(Talking());
            MainUI.SetActive(false);
            NPCUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            MainUI.SetActive(true);
            NPCUI.SetActive(false);
        }
    }
    private void Update()
    {
        if(cutsceneStart == 1)
        {
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
                Destroy(pSystems);
            }
        }
    }
    IEnumerator Talking()
    {
        mainCam.SetActive(false);
        cutSceneCam.SetActive(true);
        yield return new WaitForSeconds(2);
        cutsceneStart += 1;
    }

    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(3);
        cutsceneStart += 1;
    }
}
