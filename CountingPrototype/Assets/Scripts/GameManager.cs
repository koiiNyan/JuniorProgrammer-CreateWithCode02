using UnityEngine;
using UnityEngine.UI;

namespace FallingDownGame
{
    public class GameManager : MonoBehaviour
    {
        public Text CounterText;

        private int _count = 0;

        private void Start()
        {
            _count = 0;
        }

        public void UpdateScore()
        {
            _count++;
            CounterText.text = "Count : " + _count;
        }
    }
}
