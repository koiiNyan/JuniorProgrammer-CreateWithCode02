using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDownGame
{
    public class Ball : MonoBehaviour
    {
        private GameObject _gameManager;

        public bool Grounded = false;

        private void Awake()
        {
            _gameManager = GameObject.Find("GameManager");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            _gameManager.GetComponent<GameManager>().UpdateScore();
            StartCoroutine(DestroyBall());
        }

        private IEnumerator DestroyBall()
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log(gameObject.name);
            Destroy(gameObject);
        }

        //todo If collides with ground, destroy after 5 sec, assign grounded = true
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);
        }
    }
}
