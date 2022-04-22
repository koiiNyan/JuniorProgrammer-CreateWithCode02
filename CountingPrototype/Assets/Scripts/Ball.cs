using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDownGame
{
    public class Ball : MonoBehaviour
    {
        private GameObject _gameManager;

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
    }
}
