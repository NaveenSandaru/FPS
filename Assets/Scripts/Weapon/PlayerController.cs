using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Speeds")]
    
    [SerializeField] private float fastSpeed;
    [SerializeField] private float normalSpeed;
    
    private CharacterController characterController;

    private float gravity = 9.81f;
    private float playerMass = 55.0f;
    private float movementSpeed;
    private float jumpSpeed;
    private float xAxis;
    private float yAxis;

    Vector3 direction;
    Vector3 velocity;
    Vector3 position;

    public bool isRun; // For animation
    

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        CheckForShift();
        IsPlayerRunning();

        if (characterController.isGrounded)
        {
            direction = new Vector3(xAxis, 0f, yAxis).normalized;

            velocity = direction * movementSpeed;

            velocity = transform.transform.TransformDirection(velocity); // Rotate player character to the mouse rotation side

            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = jumpSpeed;
            }
            position = transform.position;
            position += velocity;

            transform.position = position;
        }

        velocity.y -= ((playerMass/2) * gravity) * Time.deltaTime; // Add gravity

        characterController.Move(velocity * Time.deltaTime);
    }

    private void IsPlayerRunning() 
    {
        if (yAxis != 0)
        {
            isRun = true; // For animations
            jumpSpeed = 1f * playerMass; // Jump force when running
        }
        else
        {
            isRun = false;
            jumpSpeed = 0.8f * playerMass;
        }
    }

    private void CheckForShift()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }
    }
}
