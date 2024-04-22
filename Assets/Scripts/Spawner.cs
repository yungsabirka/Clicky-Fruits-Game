using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _targetsPrefabs;

        [SerializeField] private float _targetMinSpeed = 12.0f;
        [SerializeField] private float _targetMaxSpeed = 16.0f;

        [SerializeField] private float _torqueRange = 10.0f;

        [SerializeField] private float _targetSpawnRangeX = 4.0f;
        [SerializeField] private float _targetSpawnPositionY = -2.0f;

        [SerializeField] private float _spawnRate = 1.5f;

        public void StartSpawn(float difficulty)
        {
            _spawnRate /= difficulty;
            StartCoroutine(nameof(SpawnTarget));
        }

        public void StopSpawn()
        {
            StopCoroutine(nameof(SpawnTarget));
        }

        private IEnumerator SpawnTarget()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                int index = Random.Range(0, _targetsPrefabs.Count);
                var target = Instantiate(_targetsPrefabs[index], RandomSpawnPosition(),
                    _targetsPrefabs[index].transform.rotation);

                var _targetRigidbody = target.GetComponent<Rigidbody>();

                _targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
                _targetRigidbody.AddTorque(RandomTorqueVector(), ForceMode.Impulse);
            }
        }

        private Vector3 RandomForce() =>
            Vector3.up * Random.Range(_targetMinSpeed, _targetMaxSpeed);

        private Vector3 RandomTorqueVector() =>
            new(RandomTorqueValue(), RandomTorqueValue(), RandomTorqueValue());

        private float RandomTorqueValue() =>
            Random.Range(-_torqueRange, _torqueRange);

        private Vector3 RandomSpawnPosition() =>
            new(Random.Range(-_targetSpawnRangeX, _targetSpawnRangeX), _targetSpawnPositionY);
    }
}