using System;
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
    [SerializeField]
    Container inventory;

    [SerializeField]
    int shotsFiredInClip;
    bool isReloading;
    private Guid containerItemId;

    public int ShotsRemainingInClip => clipSize - shotsFiredInClip;
    public bool IsReloading => isReloading;

    private void Awake()
    {
        // TODO: add ammo if collecting bullets?
        containerItemId = inventory.Add(this.name, maxAmmo);
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
        var ammoFromInventory = inventory.Take(containerItemId, shotsFiredInClip);
        shotsFiredInClip -= ammoFromInventory;
        isReloading = false;
        print("Reload executed");
    }
}
