using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GunScript gunScript;

    private int index;

    void Update()
    {
        index = gunScript.currentGunIndex;

        if (Input.GetMouseButtonDown(1))
        {
            if (index == 0)
            {
                _camera.fieldOfView = 50f;
            }
            else if (index == 1)
            {
                _camera.fieldOfView = 30f;
            }
            else if(index == 2)
            {
                _camera.fieldOfView = 10f;
            }
        }
        if (Input.GetMouseButtonUp(1)) 
        {
            _camera.fieldOfView = 60f;
        }
    }
}
