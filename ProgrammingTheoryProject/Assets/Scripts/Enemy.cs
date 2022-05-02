using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy
{
    public class Enemy : Unit
    {
        [SerializeField]
        private GameObject _player;
        [SerializeField]
        private GameManager _gameManager;
        [SerializeField]
        private float _attackSpeed = 3f;
        private bool _notAttacking = true;
        [SerializeField]
        private int _attackDamage = 1;

        public int Health { get; set; } = 2;

        protected override void Move()
        {
            if (IsInRangeForFollowing() && !IsInRangeForAttack())
            {
                Vector2 lookDirection = (_player.transform.position - transform.position).normalized;
                transform.Translate(-lookDirection * Time.deltaTime); 
            }
            if(IsInRangeForAttack() && _notAttacking)
            {
                StartCoroutine(Attack());
            }
            if (!IsInRangeForAttack()) _notAttacking = true;
        }

        private bool IsInRangeForFollowing() => IsInRange(3f);

        private bool IsInRangeForAttack() => IsInRange(1f);


        private bool IsInRange(float range)
        {
            float distance = Vector2.Distance(_player.transform.position, transform.position);
            if (distance < range) return true;
            else return false;
        }

        private IEnumerator Attack()
        {
            _notAttacking = false;

            while(IsInRangeForAttack())
            {
                if (_player.GetComponent<Player>().Health > 0) _player.GetComponent<Player>().Health -= _attackDamage;
                _gameManager.UpdateHpText();
                if (_player.GetComponent<Player>().Health <= 0) _gameManager.GameOver();

                yield return new WaitForSeconds(_attackSpeed);
            }
        }

    }
}
