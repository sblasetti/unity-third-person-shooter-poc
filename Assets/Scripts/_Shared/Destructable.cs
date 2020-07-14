using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField]
    float hitPoints;

    public event Action OnDeath;
    public event Action OnDamageReceived;

    float damageTaken;

    public void Reset()
    {
        damageTaken = 0;
    }

    public float GetHitPointsRemaining() {
        return hitPoints - damageTaken;
    }

    public bool IsAlive()
    {
        return GetHitPointsRemaining() > 0;
    }

    public virtual void Die()
    {
        if (IsAlive()) return;

        OnDeath?.Invoke();
    }

    public virtual void TakeDamage(float amount)
    {
        damageTaken += amount;

        OnDamageReceived?.Invoke();

        if (GetHitPointsRemaining() <= 0)
        {
            Die();
        }
    }
}
