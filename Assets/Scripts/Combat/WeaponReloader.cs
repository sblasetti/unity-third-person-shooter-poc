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

    public int ShotsRemainingInClip => clipSize - shotsFiredInClip;
    public bool IsReloading => isReloading;

    private void Awake()
    {
        ammo = maxAmmo; // TODO: using max ammo for now
    }

    public void TakeAmmoFromClip(int amount)
    {
        shotsFiredInClip += amount;
    }

    public void Reload()
    {
        print("Reload started");

        if (isReloading) return;

        isReloading = true;
        GameManager.GetInstance().GetTimer().Add(reloadTime, ExecuteReload);
    }

    public void ExecuteReload()
    {
        print("Reload executed");

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
