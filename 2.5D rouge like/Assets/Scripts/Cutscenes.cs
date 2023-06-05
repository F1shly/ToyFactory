using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public float speed;
    public float cutsceneStart = 0;
    public GameObject mainCam;
    public GameObject cutSceneCam;
    public Transform target;
    Transform camOrigin;

    private void Awake()
    {
        camOrigin = mainCam.transform;
    }
    private void Update()
    {
        if(cutsceneStart == 1)
        {
            mainCam.SetActive(false);
            cutSceneCam.SetActive(true);

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
            var step = speed * Time.deltaTime;
            cutSceneCam.transform.position = Vector3.MoveTowards(cutSceneCam.transform.position, camOrigin.position, step);
            if (Vector3.Distance(cutSceneCam.transform.position, camOrigin.position) < 1)
            {
                cutSceneCam.SetActive(false);
                mainCam.SetActive(true);
            }
        }
    }
    IEnumerator Cutscene()
    {
        yield return new WaitForSeconds(3);
        cutsceneStart += 1;
    }
}
