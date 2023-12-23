using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletMoveScript : MonoBehaviour
{
    private GameObject player;
    private GameObject lookY;
    private float bulletSpeed = 150.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookY = GameObject.FindGameObjectWithTag("LookY");

        Vector3 rotation = transform.localEulerAngles;
        rotation.y = player.transform.localEulerAngles.y;
        rotation.x = lookY.transform.localEulerAngles.x;
        transform.localEulerAngles = rotation;

        StartCoroutine(destroyBullet());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private IEnumerator destroyBullet()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(this.gameObject);
    }
}
