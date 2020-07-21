using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    InputController inputController;

    private void Awake()
    {
        inputController = GameManager.GetInstance().GetInputController();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        animator.SetFloat("Vertical", inputController.Vertical);
        animator.SetFloat("Horizontal", inputController.Horizontal);

        animator.SetBool("IsWalking", inputController.IsWalking);
        animator.SetBool("IsSprinting", inputController.IsSprinting);
    }
}
