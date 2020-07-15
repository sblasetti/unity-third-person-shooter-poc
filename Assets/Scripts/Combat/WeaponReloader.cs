using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour
{
    [SerializeField]
    int maxAmmo;
    [SerializeField]
    float reloadTime;
    [SerializeField]
    int clipSize;

    int ammo;
    int shotsFiredInClip;
    bool isReloading;

    int shotsRemainingInClip => clipSize - shotsFiredInClip;
    //public bool IsReloading => isReloading;

    public void Reload()
    {
        if (isReloading) return;

        isReloading = true;
        GameManager.GetInstance().GetTimer().Add(reloadTime, ExecuteReload);
    }

    public void ExecuteReload()
    {
        isReloading = false;
        ammo -= shotsFiredInClip;
        shotsFiredInClip = 0;

        // TODO: why could ammo be negative?
        if (ammo < 0)
        {
            shotsFiredInClip -= ammo;
            ammo = 0;
        }
    }
}
