using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private CameraRaycast _cameraRaycast;

        private TextMeshProUGUI _scoreText;
        private int _score;

        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _score = 0;
        }

        public void UpdateScore(int scoreToAdd)
        {
            _score += scoreToAdd;

            if (_score < 0)
                _score = 0;

            _scoreText.text = _score.ToString();
        }

        public void ResetScore()
        {
            _score = 0;
        }

        private void OnEnable()
        {
            _cameraRaycast.ScoreUpdated += UpdateScore;
        }
        private void OnDisable()
        {
            _cameraRaycast.ScoreUpdated -= UpdateScore;
        }
    }
}