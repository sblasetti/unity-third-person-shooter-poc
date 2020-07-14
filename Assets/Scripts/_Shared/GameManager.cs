using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event Action<Player> OnLocalPlayerJoined;
    private GameObject gameObject;
    private InputController inputController;
    private Timer timer;
    private Respawner respawner;

    #region Singleton
    private static GameManager gameManager;
    public static GameManager GetInstance()
    {
        if (gameManager == null)
        {
            gameManager = new GameManager();
            gameManager.gameObject = new GameObject("_gameManager");
            gameManager.gameObject.AddComponent<InputController>();
            gameManager.gameObject.AddComponent<Timer>();
            gameManager.gameObject.AddComponent<Respawner>();
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

    public Timer GetTimer()
    {
        if (timer == null)
        {
            timer = gameObject.GetComponent<Timer>();
        }

        return timer;
    }

    public Respawner GetRespawner()
    {
        if (respawner == null)
        {
            respawner = gameObject.GetComponent<Respawner>();
        }

        return respawner;
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
