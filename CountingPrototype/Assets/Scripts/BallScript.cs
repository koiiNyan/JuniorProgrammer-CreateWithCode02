using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FallingDownGame
{
    public class BallScript : MonoBehaviour
    {
        [SerializeField]
        private GameManager _gameManager;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger");
            _gameManager.UpdateScore();
            StartCoroutine(DestroyBall());
        }

        private IEnumerator DestroyBall()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }
    }
}
