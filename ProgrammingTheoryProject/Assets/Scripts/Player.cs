using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public class Player : Unit
    {
        public int Health { get; set; } = 5;
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _attackSpeed = 3f;
        private bool _canAttack = true;
        private Rigidbody2D _playerRb;
        private float _horizontalInput;
        private bool _canJump = true;
        [SerializeField]
        private float _jumpForce;

        [SerializeField]
        private GameManager _gameManager;


        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
        }

        protected override void Update()
        {
            base.Update();

            if (_canJump && Input.GetKeyDown(KeyCode.W)) Jump();
            if (_canAttack && Input.GetKeyDown(KeyCode.Space)) StartCoroutine(Attack());
        }


        protected override void Move()
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            //this.rB.AddForce(Vector2.right * MovementSpeed * _horizontalInput);
            transform.Translate(Vector2.right * _horizontalInput * _movementSpeed * Time.deltaTime);
        }

        private void Jump()
        {
            _canJump = false;
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _canJump = true;

            }
        }

        public void Die()
        {
            // Play death animation
            _gameManager.GameOver();
        }

        private IEnumerator Attack()
        {
            _canAttack = false;
            Debug.Log("Attack");
            yield return new WaitForSeconds(_attackSpeed);
            _canAttack = true;
        }
    }
}
