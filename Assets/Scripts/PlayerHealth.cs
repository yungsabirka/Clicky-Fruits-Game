using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Game _game;

        private int _initialHealth;
        public event Action<int> HealthChanged;

        public int Health => _health;

        public void Start()
        {
            _initialHealth = _health;
        }
        public void TakeDamage(int damage)
        {
            _health -= damage;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
            {
                _game.GameOver();
            }
        }

        public void ResetHealth()
        {
            _health = _initialHealth;
            HealthChanged?.Invoke(_health);
        }
    }
}
