using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDownGame
{
    public class Ball : MonoBehaviour
    {
        private GameObject _gameManager;
        private Rigidbody _ballRb;
        private float _ballForwardForce = 100f;

        public bool Grounded = false;
        [SerializeField]
        private float _minFallingSpeed = 1f;
        [SerializeField]
        private float _maxFallingSpeed = 50f;

        private AudioSource _ballAudio;
        [SerializeField]
        private AudioClip _ballInBox;
        [SerializeField]
        private AudioClip _ballOnFloor;

        [SerializeField]
        private ParticleSystem _smokeParticle;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager");
            _ballRb = GetComponent<Rigidbody>();
            _ballAudio = GetComponent<AudioSource>();

            _ballRb.velocity = Vector3.down * GetRandomSpeed() * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!Grounded && other.gameObject.CompareTag("Player"))
            {
                _ballAudio.PlayOneShot(_ballInBox, 1f);
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

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _ballAudio.PlayOneShot(_ballOnFloor, 1f);
                Grounded = true;
                _ballRb.AddForce(Vector3.back * _ballForwardForce, ForceMode.Acceleration);
                _smokeParticle.Play();
            }

        }
        
        private float GetRandomSpeed() => Random.Range(_minFallingSpeed, _maxFallingSpeed);

    }
}
