using Configuration;
using UnityEngine;

namespace Core
{
    public class FollowCamera : MonoBehaviour
    {
        private Transform _targetTransform;
        private GameConfig _config;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _targetOffset;

        public void Setup(GameConfig gameConfig)
        {
            _config = gameConfig;
        }

        private void FixedUpdate()
        {
            if (!_targetTransform)
                return;

            transform.position = Vector3.SmoothDamp(transform.position, _targetTransform.position + _targetOffset, ref _velocity, _config.SmoothTime);
        }

        public void SetTarget(Transform target)
        {
            _targetTransform = target;
            _targetOffset = transform.position - _targetTransform.position;
        }
    }
}