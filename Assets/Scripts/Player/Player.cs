﻿using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse;
    }

    [SerializeField]
    float runSpeed;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float sprintSpeed;
    [SerializeField]
    float crouchSpeed;

    [SerializeField]
    MouseInput mouseControl;
    InputController inputController;
    Vector2 mouseInput;

    MoveController moveController;
    public MoveController GetMoveController()
    {
        if (moveController == null)
        {
            moveController = GetComponent<MoveController>();
        }

        return moveController;
    }

    Crosshair crosshair;
    public Crosshair GetCrosshair()
    {
        if (crosshair == null)
        {
            crosshair= GetComponentInChildren<Crosshair>();
        }

        return crosshair;
    }

    void Awake()
    {
        // TODO: research about retrieving components using getters versus getting them in Awake/Start
        inputController = GameManager.GetInstance().GetInputController();
        GameManager.GetInstance().LocalPlayer = this;

        if (mouseControl.LockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        Move();

        LookAround();
    }

    private void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, inputController.MouseCoordinates.x, 1 / mouseControl.Damping.x);
        transform.Rotate(Vector3.up, mouseInput.x * mouseControl.Sensitivity.x);

        mouseInput.y = Mathf.Lerp(mouseInput.y, inputController.MouseCoordinates.y, 1 / mouseControl.Damping.y);
        GetCrosshair().LookHeight(mouseInput.y * mouseControl.Sensitivity.y);
    }

    private void Move()
    {
        var moveSpeed = runSpeed;

        if (inputController.IsWalking)
        {
            moveSpeed = walkSpeed;
        }

        if (inputController.IsSprinting)
        {
            moveSpeed = sprintSpeed;
        }

        if (inputController.IsCrouched)
        {
            moveSpeed = crouchSpeed;
        }

        var direction = new Vector2(inputController.Vertical * moveSpeed, inputController.Horizontal * moveSpeed);
        GetMoveController().Move(direction);
    }
}
