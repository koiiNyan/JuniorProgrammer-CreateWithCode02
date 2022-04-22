using System;
using UnityEngine;
using UnityEngine.UI;

namespace FallingDownGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Text _counterText;
        private int _counter = 0;

        [SerializeField]
        private GameObject ballPrefab;
        [SerializeField]
        private float _ballSpawnRangeX = 13;
        private const float _ballPositionY = 16;
        private const float _ballPositionZ = 0;
        private int _waveNumber = 1;
        private int _ballCount = 0;


        private void Start()
        {
            _counter = 0;

            SpawnBallWave(_waveNumber);
        }

        private void SpawnBallWave(int enemiesToSpawn)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(ballPrefab, GenerateSpawnPosition(), ballPrefab.transform.rotation);
                //todo add different force so balls will have different speed of falling
            }

            _waveNumber++;
        }

        public void UpdateScore()
        {
            _counter++;
            _counterText.text = "Count : " + _counter;
        }

        private Vector3 GenerateSpawnPosition()
        {
            float spawnPosX = UnityEngine.Random.Range(-_ballSpawnRangeX, _ballSpawnRangeX);
            Vector3 randomPos = new Vector3(spawnPosX, _ballPositionY, _ballPositionZ);

            return randomPos;
        }


        void Update()
        {
            var allBalls = FindObjectsOfType<Ball>();
            _ballCount = allBalls.Length;
            if (_ballCount == 0 || CheckAllActiveBallsGrounded(allBalls))
            {
                SpawnBallWave(_waveNumber);
            }

        }

        private bool CheckAllActiveBallsGrounded(Ball[] balls)
        {
            foreach (Ball ball in balls)
            {
                if (!ball.Grounded) return false;
            }
            return true;
        }
    }
}