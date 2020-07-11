using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    Player localPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GetInstance().OnLocalPlayerJoined += ThirdPersonCamera_OnLocalPlayerJoined;
    }

    private void ThirdPersonCamera_OnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
