using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Collection : MonoBehaviour
{
    private bool up;
    private float timer;

    private void Update()
    {
        if (up)
        {
            transform.position = transform.position + new Vector3(0, Time.deltaTime / 4, 0);
        }
        if (!up)
        {
            transform.position = transform.position + new Vector3(0, -Time.deltaTime / 4, 0);
        }

        timer += Time.deltaTime;
        if (timer <= 2)
        {
            up = true;
        }
        if (timer > 2)
        {
            up = false;
        }
        if (timer >= 4)
        {
            timer = 0;
        }

        transform.eulerAngles = transform.eulerAngles + new Vector3(0, Time.deltaTime * 30, 0);
    }
}
