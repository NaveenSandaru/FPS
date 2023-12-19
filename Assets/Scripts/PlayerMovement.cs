using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 1.75f;
    [SerializeField] private GameObject playerCamera;
    private bool isGrounded;
    void Start()
    {
        
    }

    void Update()
    {
        playerMovement();
        if (Input.GetKey(KeyCode.Space)&&isGrounded)
        {
            jump();
        }
    }
    private void playerMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(hInput, 0f, vInput).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GetComponent<Rigidbody>().mass = 1f;
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            GetComponent<Rigidbody>().mass = 4f;
        }
    }
}
