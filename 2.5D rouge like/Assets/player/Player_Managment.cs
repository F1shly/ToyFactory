using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Managment : MonoBehaviour
{
    Inputs inputs;
    Movement movement;

    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        inputs.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        movement.HandleAllMovement();
    }
}
