using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event Action<Player> OnLocalPlayerJoined;
    private GameObject gameObject;
    private InputController inputController;

    #region Singleton
    private static GameManager gameManager;
    public static GameManager GetInstance()
    {
        if (gameManager == null)
        {
            gameManager = new GameManager();
            gameManager.gameObject = new GameObject("_gameManager");
            gameManager.gameObject.AddComponent<InputController>();
        }

        return gameManager;
    }
    #endregion

    public InputController GetInputController()
    {
        if (inputController == null)
        {
            inputController = gameObject.GetComponent<InputController>();
        }

        return inputController;
    }

    private Player localPlayer;
    public Player LocalPlayer
    {
        get
        {
            return localPlayer;
        }
        set
        {
            localPlayer = value;
            OnLocalPlayerJoined?.Invoke(localPlayer);
        }
    }
}
