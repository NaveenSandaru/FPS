using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunPosition : MonoBehaviour
{
    [Header("First Person Positions")]
    [SerializeField] private GameObject FP_smallGunTransform;
    [SerializeField] private GameObject FP_largeGunTransform;

    [Header("Third Person Positions")]
    [SerializeField] private GameObject TP_smallGunTransform;
    [SerializeField] private GameObject TP_largeGunTransform;

    // From other scripts
    public CameraFollow cameraFollow;
    public GunScript gunScript;
    public GameObject currentGun;
    
    private bool thirdperson;
    private bool isSmallGun;
    private float smoothness = 22.5f;

    Vector3 Position;

    private void Update()
    {
        thirdperson = cameraFollow.isThirdPerson;
        isSmallGun = gunScript.isSmallGun;
        currentGun = gunScript.currentGun;

        GunsPosition();
    }

    private void GunsPosition()
    {
        Vector3 targetPosition;

        if (isSmallGun == true && thirdperson == false)
        {
            targetPosition = FP_smallGunTransform.transform.position;
        }
        else if (isSmallGun == false && thirdperson == false)
        {
            targetPosition = FP_largeGunTransform.transform.position;
        }
        else if (isSmallGun == true && thirdperson == true)
        {
            targetPosition = TP_smallGunTransform.transform.position;
        }
        else
        {
            targetPosition = TP_largeGunTransform.transform.position;
        }

        Position = Vector3.Lerp(Position, targetPosition, smoothness * Time.deltaTime);
        gunScript.currentGun.transform.position = Position;
    }
}
