using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private Animator animator;
    private bool isRun;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isRun = playerController.isRun;

        if (isRun)
        {
            animator.SetBool("PlayerRun", true);
            animator.SetBool("CameraRun", true);
        }
        else
        {
            animator.SetBool("PlayerRun", false);
            animator.SetBool("CameraRun", false);
        }
    }
}
