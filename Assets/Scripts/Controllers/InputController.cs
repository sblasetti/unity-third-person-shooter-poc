﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public Vector2 MouseCoordinates;

    public bool Fire1;
    public bool Reload;
    public bool ChangeWeapon;
    public bool MouseWheelUp;
    public bool MouseWheelDown;

    public bool IsWalking;
    public bool IsSprinting;
    public bool IsCrouched;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        var x = Input.GetAxisRaw("Mouse X");
        var y = Input.GetAxisRaw("Mouse Y");
        MouseCoordinates = new Vector2(x, y);

        Fire1 = Input.GetButton("Fire1");
        Reload = Input.GetKey(KeyCode.R);
        ChangeWeapon = Input.GetKey(KeyCode.T);
        MouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        MouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;

        IsCrouched = Input.GetKey(KeyCode.C);
        IsWalking = Input.GetKey(KeyCode.LeftAlt);
        IsSprinting = Input.GetKey(KeyCode.LeftShift);
    }
}
