using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [SerializeField] private GameObject[] shootPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float[] shootRange;
    [SerializeField] private GunScript gunScript;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clip;

    public int index;
    private GameObject currentGun;
    private Vector3 shoot_position;
    private Vector3 shoot_direction;

    private bool isFireButtonDown;

    private void Update()
    {
        currentGun = gunScript.currentGun;

        index = gunScript.currentGunIndex;  // Current gun index    0 - Pistol  1 - Rifal   2 - Sniper

        shoot_position = Camera.main.transform.position;  // Raycast start position of current gun
        shoot_direction = Camera.main.transform.forward;  // Raycast direction of current gun

        if (Input.GetMouseButtonDown(0))
        {
            isFiring();
            StartCoroutine(recoilTime(index));
            ShootEnemies();
            PlayShootSound();
        }
    }

    private void PlayShootSound()
    {
        if (index == 0)
        {
            audioSource.PlayOneShot(clip[0]);
        }
        else if (index == 1)
        {
            if (isFireButtonDown)
            {
                audioSource.PlayOneShot(clip[1]);
            }
        }
        else if (index == 2)
        {
            audioSource.PlayOneShot(clip[2]);
        }
    }

    private void isFiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFireButtonDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isFireButtonDown = false;
        }
    }

    private void ShootEnemies()
    {
        RaycastHit hitInfo; // Store raycast details

        if (Physics.Raycast(shoot_position, shoot_direction, out hitInfo, shootRange[index])) //   This returns bool value
        {
            Debug.Log(hitInfo.transform.gameObject.name);
            EnemyHealth enemyHealth = hitInfo.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(20);
            }
        }
    }

    private IEnumerator recoilTime(int index)
    {
        if (index == 0)
        {
            animator.Play("PistolRecoil");
            yield return new WaitForSecondsRealtime(0.24f);
            animator.Play("Idle");
        }
        else if (index == 1)
        {
            animator.Play("RifalRecoil");
            yield return new WaitForSecondsRealtime(0.2f);
            animator.Play("Idle");
        }
        else if (index == 2)
        {
            animator.Play("SniperRecoil");
            yield return new WaitForSecondsRealtime(0.8f);
            animator.Play("Idle");
        }
    }
}
