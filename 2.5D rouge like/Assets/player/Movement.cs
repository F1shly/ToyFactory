using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Inputs inputs;

    CharacterController controller;

    public Vector3 moveDirection;
    public Vector3 cameraDirection;

    public float speed;
    public float gravity = -10;
    public float sens = 15;

    public float lookAng;
    public float rotateSpeed = 2;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance;

    public Transform pivot;

    private Animator anim;

    private void Awake()
    {
        inputs = GetComponent<Inputs>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    public void HandleAllMovement()
    {
        Moving();
        Rotation();
    }

    private void Moving()
    {
        if(inputs.yInp == 0 && inputs.xInp == 0)
        {
            anim.SetInteger("Direction", 0);
        }
        if(inputs.yInp != 0)
        {
            if(inputs.yInp > 0)
            {
                anim.SetInteger("Direction", 1);
                if (inputs.xInp >= inputs.yInp)
                {
                    anim.SetInteger("Direction", 3);
                }
                if(inputs.xInp <= -inputs.yInp)
                {
                    anim.SetInteger("Direction", 4);
                }
            }
            if(inputs.yInp < 0)
            {
                anim.SetInteger("Direction", 2);
                if(inputs.xInp >= -inputs.yInp)
                {
                    anim.SetInteger("Direction", 3);
                }
                if(inputs.xInp <= inputs.yInp)
                {
                    anim.SetInteger("Direction", 4);
                }
            }
        }
        else if(inputs.xInp != 0)
        {
            if(inputs.xInp > 0)
            {
                anim.SetInteger("Direction", 3);
            }
            if(inputs.xInp < 0)
            {
                anim.SetInteger("Direction", 4);
            }
        }

        moveDirection = transform.forward * inputs.yInp;
        moveDirection = moveDirection + transform.right * inputs.xInp;

        moveDirection.Normalize();

        moveDirection = moveDirection * speed;
        moveDirection.y = gravity;

        Vector3 move = moveDirection;

        controller.Move(move * Time.deltaTime * speed);
    }

    private void Rotation()
    {
        Vector3 rotation = Vector3.zero;

        lookAng = lookAng + (inputs.rotInpX * rotateSpeed);

        rotation = Vector3.zero;
        rotation.y = lookAng;
        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        targetRotation = Quaternion.Euler(rotation);
        pivot.localRotation = targetRotation;
    }

    private void Update()
    {
        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
