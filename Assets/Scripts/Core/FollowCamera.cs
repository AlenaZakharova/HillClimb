using Configuration;
using UnityEngine;

namespace Core
{
    public class FollowCamera : MonoBehaviour
    {
        private Transform _targetTransform;
        private GameConfig _config;

        private Vector3 _targetOffset;

        public void Setup(GameConfig gameConfig)
        {
            _config = gameConfig;
        }

        private void Awake()
        {
            _targetOffset = transform.position;
        }

        private void FixedUpdate()
        {
            if (!_targetTransform)
                return;

            transform.position = Vector3.Lerp(transform.position, GetDestinationPosition(),
                _config.CameraStickiness * Time.fixedDeltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(
                _targetTransform.position
                + new Vector3(0, _config.CameraAdditionalVerticalRotation, 0)
                - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation,
                targetRotation, _config.CameraRotationStickiness);
        }

        public void SetTarget(Transform target)
        {
            _targetTransform = target;
        }

        private Vector3 GetDestinationPosition()
        {
            return _targetTransform.TransformPoint(_targetOffset);
        }
    }
}