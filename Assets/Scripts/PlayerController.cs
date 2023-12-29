using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpSpeed = 5.0f;
    
    private CharacterController characterController;

    private float gravity = 9.81f;
    private float xAxis;
    private float yAxis;

    Vector3 direction;
    Vector3 velocity;
    Vector3 position;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        CheckForShift();

        if (characterController.isGrounded)
        {
            direction = new Vector3(xAxis, 0f, yAxis);

            velocity = direction * movementSpeed;
            velocity = transform.transform.TransformDirection(velocity);

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
            }

            position = transform.position;
            position += velocity;
            transform.position = position;
        }
        
        velocity.y -= gravity * Time.deltaTime; // Add gravity
        
        characterController.Move(velocity * Time.deltaTime);
    }

    private void CheckForShift()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = 8.0f;
        }
        else
        {
            movementSpeed = 5.0f;
        }
    }
}
