using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public GameObject room_cam;
    GameObject player;
    Camera camera;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = Camera.main;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>())
        {
            camera.transform.position = room_cam.transform.position;
            camera.transform.rotation = room_cam.transform.rotation;
        }
    }
}
