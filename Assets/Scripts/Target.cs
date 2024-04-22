using UnityEngine;

namespace Assets.Scripts
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _scoreByKill;
        [SerializeField] private ParticleSystem _explosionParticle;

        public int Damage => _damage;
        public int ScoreByKill => _scoreByKill;

        public void Kill()
        {
            Destroy(gameObject);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        }
    }
}