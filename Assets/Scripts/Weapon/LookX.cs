using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;

    private float xAxis;

    void Update()
    {
        xAxis = Input.GetAxis("Mouse X");

        Vector3 rotation = transform.localEulerAngles;
        rotation.y += xAxis * rotationSpeed;
        transform.localEulerAngles = rotation;
    }
}
