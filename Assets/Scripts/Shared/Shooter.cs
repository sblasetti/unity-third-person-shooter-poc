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

    float nextFireAllowed;
    internal bool canFire;

    // Start is called before the first frame update
    void Awake()
    {
        muzzle = transform.Find("Muzzle");
    }

    public virtual void Fire()
    {
        canFire = (Time.time >= nextFireAllowed);
        if (!canFire) return;

        nextFireAllowed = Time.time + rateOfFire;

        Instantiate(projectile, muzzle.position, muzzle.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
