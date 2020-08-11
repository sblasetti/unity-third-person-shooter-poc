using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    Projectile projectile;
    [HideInInspector]
    Transform muzzle;

    Transform weaponsContainerTransform;
    WeaponReloader reloader;

    float nextFireAllowed;
    internal bool canFire;

    public virtual void Fire()
    {
        canFire = Time.time >= nextFireAllowed;
        if (!canFire) return;

        if (reloader != null)
        {
            if (reloader.IsReloading) return;
            if (reloader.ShotsRemainingInClip == 0) return;

            reloader.TakeAmmoFromClip(1); // TODO: make it a prop
        }

        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(projectile, muzzle.position, muzzle.rotation);

    }

    void Awake()
    {
        weaponsContainerTransform = transform.Find("Weapons");
        muzzle = transform.Find("Container/Muzzle");
        reloader = GetComponent<WeaponReloader>();
    }

    void Update()
    {
        if (reloader != null && !reloader.IsReloading && GameManager.GetInstance().GetInputController().Reload)
        {
            reloader.Reload();
        }
    }
}
