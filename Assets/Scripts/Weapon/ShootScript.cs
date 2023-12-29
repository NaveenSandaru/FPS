using System.Collections;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private float[] shootRange;
    [SerializeField] private GunScript gunScript;

    [Header("Animations")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clip;

    private int[] currentAmmoAmount;
    private int[] MaxAmmoAmount;

    private GameObject currentGun;
    private Vector3 shoot_position;
    private Vector3 shoot_direction;

    private bool isFireButtonDown;
    private bool canFire = false;

    public int index;
    public int maxAmmo;
    public int currentAmmo;

    private void Start()
    {
        MaxAmmoAmount = new int[3];
        currentAmmoAmount = new int[3];

        MaxAmmoAmount[0] = 6;
        MaxAmmoAmount[1] = 20;
        MaxAmmoAmount[2] = 3;

        currentAmmoAmount[0] = MaxAmmoAmount[0];
        currentAmmoAmount[1] = MaxAmmoAmount[1];
        currentAmmoAmount[2] = MaxAmmoAmount[2];
    }

    private void Update()
    {
        currentGun = gunScript.currentGun;
        
        index = gunScript.currentGunIndex;  // Current gun index    0 - Pistol  1 - Rifal   2 - Sniper
        
        maxAmmo = MaxAmmoAmount[index];         // Use in UIManagerScript
        currentAmmo = currentAmmoAmount[index];

        shoot_position = Camera.main.transform.position;  // Raycast start position of current gun
        shoot_direction = Camera.main.transform.forward;  // Raycast direction of current gun

        CheckBullets();
        Reload();
        isFiring();
        Shoot();
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

    private void CheckBullets()
    {
        if (currentAmmoAmount[index] > 0)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
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
            ReduceBullet();
            StartCoroutine(recoilTime(index));
            PlayShootSound();
        }
    }

    private IEnumerator recoilTime(int index)
    {
        if (index == 0)
        {
            animator.Play("PistolRecoil");
            canFire = false;
            yield return new WaitForSecondsRealtime(0.24f);
            animator.Play("Idle");
        }
        else if (index == 1)
        {
            animator.Play("RifalRecoil");

            canFire = false;
            yield return new WaitForSecondsRealtime(0.2f);
            animator.Play("Idle");
        }
        else if (index == 2)
        {
            animator.Play("SniperRecoil");
            canFire = false;
            yield return new WaitForSecondsRealtime(0.8f);
            animator.Play("Idle");
        }
    }

    private void ReduceBullet()
    {
        currentAmmoAmount[index] -= 1;
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

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentAmmoAmount[index] = MaxAmmoAmount[index];
        }
    }
}
