using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3[] normalPosition;
    [SerializeField] private Vector3[] aimPosition;
    [SerializeField] private GunScript gunScript;

    private int index;
    private GameObject currentGun;

    private void Start()
    {
        _camera.fieldOfView = 60f;
    }

    void Update()
    {
        index = gunScript.currentGunIndex;
        currentGun = gunScript.currentGun;

        FieldOfView();
    }

    private void FieldOfView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (index == 0)
            {
                _camera.fieldOfView = 50f;
                AimPosition(index);
            }
            else if (index == 1)
            {
                _camera.fieldOfView = 30f;
                AimPosition(index);
            }
            else if (index == 2)
            {
                _camera.fieldOfView = 20f;
                AimPosition(index);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            _camera.fieldOfView = 60f;
            NormalPosition(index);
        }
    }

    private void NormalPosition(int i)
    {
        currentGun.transform.localPosition = normalPosition[i];
    }

    private void AimPosition(int i)
    {
        currentGun.transform.localPosition = aimPosition[i];
    }
}
