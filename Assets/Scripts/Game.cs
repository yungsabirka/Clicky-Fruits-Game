using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private GameObject _titleScreenUI;
        [SerializeField] private GameObject _scoreUI;
        [SerializeField] private GameObject _healthUI;
        public void StartGame(float difficulty)
        {
            _titleScreenUI.SetActive(false);
            _scoreUI.SetActive(true);
            _healthUI.SetActive(true);
            _spawner.StartSpawn(difficulty);
        }

        public void GameOver()
        {
            _gameOverUI.SetActive(true);
            _spawner.StopSpawn();
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}