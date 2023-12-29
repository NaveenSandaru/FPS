using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject[] holsters;
    [SerializeField] public GameObject hand;

    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;

    public int weaponNum;

    void Start()
    {
        initialPositions = new Vector3[guns.Length];
        initialRotations = new Quaternion[guns.Length];

        for (int i = 0; i < guns.Length; i++)
        {
            initialPositions[i] = guns[i].transform.localPosition;
            initialRotations[i] = guns[i].transform.localRotation;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponNum = 0;
            holsterAR();
            holsterSniper();
            drawPistol();
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponNum = 1;
            holsterPistol();
            holsterSniper();
            drawAR();
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponNum = 2;
            holsterPistol();
            holsterAR();
            drawSniper();
        }
        if (Input.GetKey(KeyCode.H))
        {
            holsterPistol();
            holsterAR();
            holsterSniper();
        }
    }

    private void holsterPistol()
    {
        Holster(0);
    }

    private void holsterAR()
    {
        Holster(1);
    }

    private void holsterSniper()
    {
        Holster(2);
    }

    private void drawPistol()
    {
        Draw(0);
    }

    private void drawAR()
    {
        Draw(1);
    }

    private void drawSniper()
    {
        Draw(2);
    }

    private void Holster(int index)
    {
        if (guns[index].transform.parent == hand.transform)
        {
            guns[index].transform.SetParent(holsters[index].transform);
            guns[index].transform.localPosition = initialPositions[index];
            guns[index].transform.localRotation = initialRotations[index];
        }
    }

    private void Draw(int index)
    {
        guns[index].transform.SetParent(hand.transform);
        if (index == 0) hand.transform.rotation = Quaternion.Euler(60f, 120f, 30f);
        if (index == 1) hand.transform.rotation = Quaternion.Euler(0f, 5f, 120f);
        if (index == 2) hand.transform.rotation = Quaternion.Euler(0, 0, 90f);
        guns[index].transform.localPosition = initialPositions[index];
        guns[index].transform.localRotation = initialRotations[index];
    }
}
