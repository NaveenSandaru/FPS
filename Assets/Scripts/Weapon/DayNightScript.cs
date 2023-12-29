using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light directionalLight;

    private void Update()
    {
        Vector3 rotation = directionalLight.transform.eulerAngles;
        rotation.x += 0.02f * Time.deltaTime;
        directionalLight.transform.eulerAngles = rotation;
    }
}
