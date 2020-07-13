using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Health : Destructable
    {
        public override void Die()
        {
            base.Die();

            print("we died");
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            print($"Remaining {GetHitPointsRemaining()}");
        }
    }
}
