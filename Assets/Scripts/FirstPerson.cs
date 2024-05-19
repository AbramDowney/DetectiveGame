using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FirstPerson : MonoBehaviour
{
    public Camera playerCamera;

    public float walk = 5;
    public float run = 10;
    public float jump = 5;
    public float gravity = 10;

    public float look = 2;
    public float limit = 50;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public Boolean canMove = true;

    CharacterController characterContoller;

    void Start() {
        characterContoller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Boolean isRunning = Input.GetKey(KeyCode.LeftShift);
        float SpeedX = canMove ? (isRunning ? run : walk) * Input.GetAxis("Vertical") : 0;
        float SpeedY = canMove ? (isRunning ? run : walk) * Input.GetAxis("Horizontal") : 0;
        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * SpeedX) + (right * SpeedY);
    
        if(Input.GetButton("Jump") && canMove && characterContoller.isGrounded) {
            moveDirection.y = jump;
        }

        else {
            moveDirection.y = moveDirectionY;
        }

        if(!characterContoller.isGrounded){
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if(canMove){
            rotationX += -Input.GetAxis("Mouse Y") * look;
            rotationX = Mathf.Clamp(rotationX, -limit, limit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * look, 0);
        }
    }
}

