using UnityEngine;
using UnityEngine.UI;

namespace Jumpy
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Text _hpText;
        [SerializeField]
        private GameObject _player;

        private void Awake()
        {
            UpdateHpText();
        }

        public void UpdateHpText()
        {
            _hpText.text = _player.GetComponent<Player>().Health.ToString();
        }

        public void GameOver()
        {
            Time.timeScale = 0;
        }
    }
}
