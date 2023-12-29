using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class WeaponBehaviour : MonoBehaviour
{
    private WeaponSwitching weaponSwitching;
    [SerializeField] private GameObject UI;
    void Start()
    {
        weaponSwitching = GetComponent<WeaponSwitching>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(weaponSwitching.weaponNum == 0) weaponSwitching.hand.transform.rotation = Quaternion.Euler(90, 60, -120);
            if(weaponSwitching.weaponNum == 1) weaponSwitching.hand.transform.rotation = Quaternion.Euler(180,270,-90);
            if (weaponSwitching.weaponNum == 2) weaponSwitching.hand.transform.rotation = Quaternion.Euler(0, 80, 90);
            UI.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            Invoke("resetWeaponPos", 2f);
        }
    }
    private void resetWeaponPos()
    {
        if (weaponSwitching.weaponNum == 0) weaponSwitching.hand.transform.rotation = Quaternion.Euler(60f, 120f, 30f);
        if (weaponSwitching.weaponNum == 1) weaponSwitching.hand.transform.rotation = Quaternion.Euler(0f, 5f, 120f);
        if (weaponSwitching.weaponNum == 2) weaponSwitching.hand.transform.rotation = Quaternion.Euler(0, 0, 90f);
        UI.gameObject.SetActive(false);
    }
}
