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
        [SerializeField]
        float respawnTimeInSeconds;

        public override void Die()
        {
            base.Die();

            GameManager.GetInstance().GetRespawner().Despawn(gameObject, respawnTimeInSeconds);
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            print($"Remaining {GetHitPointsRemaining()}");
        }

        private void OnEnable()
        {
            Reset();
        }
    }
}
