using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject lookY;

    [Header("First Person Positions")]
    [SerializeField] private GameObject FP_smallGunTransform;
    [SerializeField] private GameObject FP_largeGunTransform;

    [Header("Third Person Positions")]
    [SerializeField] private GameObject TP_smallGunTransform;
    [SerializeField] private GameObject TP_largeGunTransform;

    public CameraFollow cameraFollow;
    public bool thirdperson;

    private GameObject currentGun;
    private bool isSmallGun = true;

    Vector3 position;

    private void Start()
    {
        SwitchGun(0);
    }

    private void Update()
    {
        GunPosition();
        SelectGun();
    }

    private void SelectGun()
    {
        if (Input.GetKeyDown("1"))
        {
            isSmallGun = true;
            StartCoroutine(SwitchTime(0));
        }
        if (Input.GetKeyDown("2"))
        {
            isSmallGun = false;
            StartCoroutine(SwitchTime(1));
        }
        if (Input.GetKeyDown("3"))
        {
            isSmallGun = false;
            StartCoroutine(SwitchTime(2));
        }
    }

    private IEnumerator SwitchTime(int i)
    {
        currentGun.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        SwitchGun(i);
    }

    private void GunPosition()
    {
        thirdperson = cameraFollow.isThirdPerson;

        position = currentGun.transform.position;

        if (isSmallGun == true && thirdperson == false)
        {
            position = FP_smallGunTransform.transform.position;
        }
        else if (isSmallGun == false && thirdperson == false)
        {
            position = FP_largeGunTransform.transform.position;
        }
        else if (isSmallGun == true && thirdperson == true)
        {
            position = TP_smallGunTransform.transform.position;
        }
        else if (isSmallGun == false && thirdperson == true)
        {
            position = TP_largeGunTransform.transform.position;
        }

        currentGun.transform.position = position;
    }

    private void SwitchGun(int index)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == index)
            {
                guns[i].SetActive(true);
                currentGun = guns[i];
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }
}
