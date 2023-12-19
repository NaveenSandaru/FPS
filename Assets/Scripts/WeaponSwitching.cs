using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private GameObject handGun;
    [SerializeField] private GameObject handGunHolster;
    [SerializeField] private GameObject sniperRifle;
    [SerializeField] private GameObject sniperRifleHolster;
    [SerializeField] private GameObject assaultRifle;
    [SerializeField] private GameObject assaultRifleHolster;
    [SerializeField] private GameObject hand;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            holsterAR();
            holsterSniper();
            drawPistol();
            
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            holsterPistol();
            holsterSniper();
            drawAR();
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            holsterPistol();
            holsterAR();
            drawSniper();
        }
        if (Input.GetKey(KeyCode.H)) {
            holsterPistol();
            holsterAR();
            holsterSniper();
            
        }
    }
    private void holsterPistol()
    {
        if (handGun.transform.parent == hand.transform)
        {
            handGun.transform.SetParent(handGunHolster.transform);
            handGun.transform.localPosition = Vector3.zero;
            handGun.transform.localRotation = Quaternion.identity;
        }
    }
    private void holsterAR()
    {
        if (assaultRifle.transform.parent == hand.transform)
        {
            assaultRifle.transform.SetParent(assaultRifleHolster.transform);
            assaultRifle.transform.localPosition = Vector3.zero;
            assaultRifle.transform.localRotation = Quaternion.identity;
        }
    }
    private void holsterSniper()
    {
        if (sniperRifle.transform.parent == hand.transform)
        {
            sniperRifle.transform.SetParent(sniperRifleHolster.transform);
            sniperRifle.transform.localPosition = Vector3.zero;
            sniperRifle.transform.localRotation = Quaternion.identity;
        }
    }
    private void drawPistol()
    {
        handGun.transform.SetParent(hand.transform);
        handGun.transform.localPosition = Vector3.zero;
        handGun.transform.localRotation = Quaternion.identity;
    }
    private void drawAR()
    {
        assaultRifle.transform.SetParent(hand.transform);
        assaultRifle.transform.localPosition = Vector3.zero;
        assaultRifle.transform.localRotation = Quaternion.identity;
    }
    private void drawSniper()
    {
        sniperRifle.transform.SetParent(hand.transform);
        sniperRifle.transform.localPosition = Vector3.zero;
        sniperRifle.transform.localRotation = Quaternion.identity;
    }
}

