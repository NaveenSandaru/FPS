using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;

    private Rigidbody Rbody;
    private float yAxis;
    private float mouseY;

    private void Start()
    {
        Rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        yAxis = Input.GetAxis("Mouse Y");

        mouseY -= yAxis * rotationSpeed;

        mouseY = Mathf.Clamp(mouseY, -55, 55);
        transform.localEulerAngles = new Vector3(mouseY, 0f, 0f);
    }
}
