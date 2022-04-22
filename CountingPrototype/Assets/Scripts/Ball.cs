using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDownGame
{
    public class Ball : MonoBehaviour
    {
        private GameObject _gameManager;
        private Rigidbody _ballRb;

        public bool Grounded = false;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager");
            _ballRb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!Grounded && other.gameObject.CompareTag("Player"))
            {
                _gameManager.GetComponent<GameManager>().UpdateScore();
                StartCoroutine(DestroyBall());
            }

            if (other.gameObject.CompareTag("Wall")) Destroy(gameObject);
        }

        private IEnumerator DestroyBall()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }

        //todo If collides with ground, move forward to camera, assign grounded = true, remove when ball is not in camera view
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                Grounded = true;
                _ballRb.AddForce(Vector3.back * 100f, ForceMode.Acceleration);
            }

        }
    }
}
