using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    float rateOfFire;
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
        if (canFire)
        {
            nextFireAllowed = Time.time + rateOfFire;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
