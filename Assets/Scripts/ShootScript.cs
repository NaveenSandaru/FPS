using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject[] shootPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float[] shootRange;
    [SerializeField] private GunScript gunScript;

    public int index;
    private GameObject spawnedBullet;
    private Vector3 shoot_position;
    private Vector3 shoot_direction;

    private void Update()
    {
        if (gunScript != null)
        {
            index = gunScript.currentGunIndex;  // Current gun index    0 - Pistol  1 - Rifal   2 - Sniper
        }

        if (shootPosition != null && index < shootPosition.Length)
        {
            shoot_position = shootPosition[index].transform.position;  // Raycast start position of current gun
            shoot_direction = shootPosition[index].transform.forward;  // Raycast direction of current gun
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo; // Store raycast details

            if (Physics.Raycast(shoot_position , shoot_direction, out hitInfo, shootRange[index])) //   This returns bool value
            {
                spawnedBullet = Instantiate(bullet);
                spawnedBullet.transform.position = shoot_position;
            }
            else
            {
                return; //  Avoid errors
            }
        }
    }
}
