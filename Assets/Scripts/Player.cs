using Assets.Scripts;
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
    }

    [SerializeField]
    float speed;
    [SerializeField]
    MouseInput mouseControl;
    InputController inputController;
    MoveController moveController;

    public MoveController GetMoveController()
    {
        if (moveController == null)
        {
            moveController = GetComponent<MoveController>();
        }

        return moveController;
    }

    void Awake()
    {
        inputController = GameManager.GetInstance().GetInputController();
        // TODO: research about retrieving components using getters versus getting them in Awake/Start
    }

    void Update()
    {
        var direction = new Vector2(inputController.Vertical * speed, inputController.Horizontal * speed);
        GetMoveController().Move(direction);
    }
}
