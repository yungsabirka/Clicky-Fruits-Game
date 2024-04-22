using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;

        private TextMeshProUGUI _healthText;

        private void Start()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
            UpdateHealth(_health.Health);
        }
        private void OnEnable()
        {
            _health.HealthChanged += UpdateHealth;
        }

        private void OnDisable()
        {
            _health.HealthChanged -= UpdateHealth;
        }

        private void UpdateHealth(int health)
        {
            _healthText.text = health > 0 ? health.ToString() : "0";
        }
    }
}
