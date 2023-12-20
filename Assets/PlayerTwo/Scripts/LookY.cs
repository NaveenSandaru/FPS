using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;

    [SerializeField] private GunScript gunScript;

    private float yAxis;
    private float mouseY;
    private bool thirdPerson;
    
    void Update()
    {
        yAxis = Input.GetAxis("Mouse Y");
        thirdPerson = gunScript.thirdperson;

        mouseY -= yAxis * rotationSpeed;

        if (thirdPerson)
        {
            mouseY = Mathf.Clamp(mouseY, -34, 34);
        }
        else
        {
            mouseY = Mathf.Clamp(mouseY, -55, 55);
        }

        transform.localEulerAngles = new Vector3(mouseY, 0f, 0f);
    }
}
