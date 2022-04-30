using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public abstract class Unit : MonoBehaviour
    {
        protected int Health { get; set; }
        protected float _movementSpeed;
        protected float MovementSpeed { get => _movementSpeed; 
            
            set
            {
                if (value < 0.0f)
                {

                    Debug.LogError("You can't set a negative MovementSpeed!");
                }
                else
                {
                    _movementSpeed = value;
                }
            }
        }
        protected float AttackSpeed { get; set; }

        protected Rigidbody2D rB { get; set; }


        private void Update()
        {
            Move();
        }
        protected abstract void Move();

    }
}
