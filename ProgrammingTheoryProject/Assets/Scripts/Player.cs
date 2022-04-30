using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public class Player : Unit
    {
        public float horizontalInput;
        public float verticalInput;
        private bool _canJump;


        private void Awake()
        {
            this.MovementSpeed = 5f;
            this.rB = GetComponent<Rigidbody2D>();
            
        }

       
        protected override void Move()
        {
            horizontalInput = Input.GetAxis("Horizontal");
            this.rB.AddForce(Vector2.right * MovementSpeed * horizontalInput);
        }

        protected override void Jump()
        {

        }

    }
}
