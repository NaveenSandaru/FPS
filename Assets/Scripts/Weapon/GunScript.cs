using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject lookY;

    [SerializeField] private GameObject FP_smallGunTransform;
    [SerializeField] private GameObject FP_largeGunTransform;
    [SerializeField] private GameObject TP_smallGunTransform;
    [SerializeField] private GameObject TP_largeGunTransform;

    public CameraFollow cameraFollow;

    private GameObject currentGun;

    private bool thirdperson;
    private bool isSmallGun = true;

    private Vector3 offset = new Vector3(0f, 0f, 3f);

    private void Start()
    {
        SwitchGun(0);
    }

    private void Update()
    {
        SelectGun();
        
    }
    private void LateUpdate()
    {
        GunPosition();
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

        if (isSmallGun == true && thirdperson == false)
        {
            currentGun.transform.position = FP_smallGunTransform.transform.position;
        }
        else if (isSmallGun == false && thirdperson == false)
        {
            currentGun.transform.position = FP_largeGunTransform.transform.position;
        }
        else if (isSmallGun == true && thirdperson == true)
        {
            currentGun.transform.position = TP_smallGunTransform.transform.position;
        }
        else if (isSmallGun == false && thirdperson == true)
        {
            currentGun.transform.position = TP_largeGunTransform.transform.position;
        }
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
