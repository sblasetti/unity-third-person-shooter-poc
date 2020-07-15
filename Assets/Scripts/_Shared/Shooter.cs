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

    WeaponReloader reloader;

    float nextFireAllowed;
    internal bool canFire;

    // Start is called before the first frame update
    void Awake()
    {
        muzzle = transform.Find("Muzzle");
        reloader = GetComponent<WeaponReloader>();
    }

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

    // Update is called once per frame
    void Update()
    {
        if (reloader != null && !reloader.IsReloading && GameManager.GetInstance().GetInputController().Reload)
        {
            reloader.Reload();
        }
    }
}
