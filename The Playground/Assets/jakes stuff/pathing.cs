using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathing : MonoBehaviour
{
    public GameObject start, end;
    public float speed;
    float curved_speed;
    public bool curve;
    bool waited;
    public float test1, test2;
    
    private void Awake()
    {
        waited = false;
    }
    private void Update()
    {
        float proxX, proxY;


        proxX = transform.position.x - end.transform.position.x;
        proxY = transform.position.z - end.transform.position.z;
        test1 = proxX;
        test2 = proxY;

        StartCoroutine(wait());
        if(waited)
        {
            Vector3 Start, End;
            Start = new Vector3(start.transform.position.x, start.transform.position.y + 70, start.transform.position.z);
            End = new Vector3(end.transform.position.x, end.transform.position.y + 70, end.transform.position.z);

            if (curve)
            {
                curved_speed += Time.deltaTime;
                transform.position = Vector3.Slerp(Start, End, curved_speed / speed);
            }
            else
            {
                float step = speed + Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, End, step / 15);
            }
        }
        if(proxX > -15 && proxX < 15
            && proxY > -15 && proxY < 15)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        if(!waited)
        {
            transform.position = new Vector3(start.transform.position.x, start.transform.position.y + 70,start.transform.position.z);
        }
        waited = true;
    }
}
