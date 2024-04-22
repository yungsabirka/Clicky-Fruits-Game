using UnityEngine;

namespace Assets.Scripts
{
    public class Sensor : MonoBehaviour
    {
        [SerializeField] PlayerHealth _health;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Target>(out var target))
            {
                _health.TakeDamage(target.Damage);
                Destroy(target.gameObject);
            }
        }
    }
}
