using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;
    public Vector2 MouseCoordinates;
    public bool Fire1;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        var x = Input.GetAxisRaw("Mouse X");
        var y = Input.GetAxisRaw("Mouse Y");
        MouseCoordinates = new Vector2(x, y);

        Fire1 = Input.GetButton("Fire1");
    }
}
