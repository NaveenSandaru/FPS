using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject firstPersonPosition;
    [SerializeField] private GameObject thirdPersonPosition;

    private Vector3 cameraPosition;

    private bool isThirdPerson = false;

    private void Start()
    {
        _camera.transform.position = firstPersonPosition.transform.position;
    }

    void LateUpdate()
    {
        cameraPosition = _camera.transform.position;

        if (Input.GetKeyDown(KeyCode.V))
        {
            isThirdPerson = !isThirdPerson;
        }

        if (isThirdPerson)
        {
            cameraPosition = thirdPersonPosition.transform.position;
        }
        else
        {
            cameraPosition = firstPersonPosition.transform.position;
        }

        _camera.transform.position = cameraPosition;
    }
}
