using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject lookY;

    public GameObject currentGun;
    public int currentGunIndex;
    public bool isSmallGun = true;

    private void Start()
    {
        SwitchGun(0);
    }

    private void Update()
    {
        SelectGun();
    }

    private void SelectGun()
    {
        if (Input.GetKeyDown("1"))
        {
            if (currentGunIndex == 0) // Ignore retake the same gun
            {
                return;
            }

            isSmallGun = true;
            StartCoroutine(SwitchTime(0));
        }
        if (Input.GetKeyDown("2"))
        {
            if (currentGunIndex == 1)
            {
                return;
            }

            isSmallGun = false;
            StartCoroutine(SwitchTime(1));
        }
        if (Input.GetKeyDown("3"))
        {
            if (currentGunIndex == 2)
            {
                return;
            }

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

    private void SwitchGun(int index)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == index)
            {
                currentGunIndex = i;
                currentGun = guns[i];
                guns[i].SetActive(true);
            }
            else
            {
                guns[i].SetActive(false);
            }
        }
    }
}
