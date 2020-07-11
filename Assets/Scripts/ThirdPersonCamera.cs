using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    Vector3 cameraOffset;
    [SerializeField]
    float damping;

    Transform cameraLookTarget;
    Player localPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.GetInstance().OnLocalPlayerJoined += ThirdPersonCamera_OnLocalPlayerJoined;
    }

    private void ThirdPersonCamera_OnLocalPlayerJoined(Player player)
    {
        localPlayer = player;
        
        cameraLookTarget = localPlayer.transform.Find("CameraLookTarget");
        if (cameraLookTarget == null)
        {
            cameraLookTarget = localPlayer.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var rightOffset = localPlayer.transform.forward * cameraOffset.x;
        var upOffset = localPlayer.transform.forward * cameraOffset.y;
        var forwardOffset = localPlayer.transform.forward * cameraOffset.z;
        var targetPosition = cameraLookTarget.position + rightOffset + upOffset + forwardOffset;

        var targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

        transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);
    }
}
