using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject firstPersonPosition;

    private Vector3 cameraPosition;

    private void Start()
    {
        _camera.transform.position = firstPersonPosition.transform.position;
    }

    void LateUpdate()
    {
        cameraPosition = _camera.transform.position;

        cameraPosition = firstPersonPosition.transform.position;

        _camera.transform.position = cameraPosition;
    }
}
