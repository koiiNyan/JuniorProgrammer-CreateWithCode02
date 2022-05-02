using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public abstract class Unit : MonoBehaviour
    {

        protected virtual void Update()
        {
            Move();

        }
        protected abstract void Move();


    }
}
