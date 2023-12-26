using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] private TMP_Text Curr_Ammo;
    [SerializeField] private TMP_Text Max_Ammo;
    [SerializeField] private ShootScript shootScript;

    private int MaxAmmoAmount;
    private int CurrentAmmoAmount;

    void Update()
    {
        MaxAmmoAmount = shootScript.maxAmmo;
        CurrentAmmoAmount = shootScript.currentAmmo;

        Curr_Ammo.text = CurrentAmmoAmount.ToString();
        Max_Ammo.text = MaxAmmoAmount.ToString();
    }
}
