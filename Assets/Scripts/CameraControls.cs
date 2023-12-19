using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject TPP;
    [SerializeField] private GameObject FPP;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private float mouseSensitivity = 2f;
    private bool isFPS = true;

    void Start()
    {
        playerCamera.SetActive(true);
        SwitchToFPP();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && isFPS)
        {
            SwitchToTPP();
        }
        else if (Input.GetKeyDown(KeyCode.V) && !isFPS)
        {
            SwitchToFPP();
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);

        float currentRotationX = playerCamera.transform.localRotation.eulerAngles.x;
        float newRotationX = Mathf.Clamp(currentRotationX - mouseY * mouseSensitivity,-165,165);
        playerCamera.transform.localRotation = Quaternion.Euler(newRotationX, 0f, 0f);
    }

    private void SwitchToFPP()
    {
        playerCamera.transform.SetParent(FPP.transform);
        playerCamera.transform.localPosition = Vector3.zero;
        playerCamera.transform.localRotation = Quaternion.identity;
        isFPS = true;
    }

    private void SwitchToTPP()
    {
        playerCamera.transform.SetParent(TPP.transform);
        playerCamera.transform.localPosition = Vector3.zero;
        playerCamera.transform.localRotation = Quaternion.identity;
        isFPS = false;
    }
}
