using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public class Player : Unit
    {
        private float _horizontalInput;
        [SerializeField] private bool _canJump = true;
        [SerializeField]
        private float _jumpForce;


        private void Awake()
        {
            this.MovementSpeed = 2f;
            this.rB = GetComponent<Rigidbody2D>();

        }

        protected override void Update()
        {
            base.Update();

            if (_canJump && Input.GetKeyDown(KeyCode.W)) Jump();
        }


        protected override void Move()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            this.rB.AddForce(Vector2.right * MovementSpeed * _horizontalInput);
        }

        protected void Jump()
        {
            _canJump = false;
            this.rB.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _canJump = true;

            }
        }

    }
}
