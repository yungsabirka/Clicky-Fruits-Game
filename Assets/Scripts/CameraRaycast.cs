using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraRaycast : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private float _rayLenght;

        private LayerMask _targetLayer = 1 << 6;

        public event Action<int> ScoreUpdated;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _rayLenght, _targetLayer))
                {
                    var target = hit.collider.GetComponent<Target>();
                    target.Kill();
                    ScoreUpdated?.Invoke(target.ScoreByKill);
                }
            }
        }
    }
}
