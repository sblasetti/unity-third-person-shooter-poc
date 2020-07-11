using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoveController : MonoBehaviour
    {
        public void Move(Vector2 direction)
        {
            Vector3 forwardVector = transform.forward * direction.x * Time.deltaTime;
            Vector3 rightVector = transform.right * direction.y * Time.deltaTime;
            transform.position += forwardVector + rightVector;
        }
    }
}
