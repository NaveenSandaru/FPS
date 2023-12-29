using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;

    private float yAxis;
    private float mouseY;
    
    void Update()
    {
        yAxis = Input.GetAxis("Mouse Y");

        mouseY -= yAxis * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -30, 30);

        transform.localEulerAngles = new Vector3(mouseY, 0f, 0f);
    }
}