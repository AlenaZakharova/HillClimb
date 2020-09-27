using Configuration;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game : IGame
    {
        private readonly IMeta _meta;
        private readonly GameConfig _config;
        private readonly FollowCamera _followCamera;
        private bool _isPlaying;
        private Car _car;
        private float _traversedPath;
        private float _startCarPositionX;

        public int TraversedPath => (int)_traversedPath;

        public Game(IMeta meta, GameConfig config, FollowCamera followCamera)
        {
            _meta = meta;
            _config = config;
            _followCamera = followCamera;
        }

        public void Setup()
        {
            CleanUp();

            _car = Object.Instantiate(_config.CarPrefab, _config.StartPosition, Quaternion.identity);
            _car.Setup(_config);
            _car.DriverIsDead += OnDriverDead;

            _followCamera.ResetPosition();
            _followCamera.SetTarget(_car.transform);

            _startCarPositionX = _car.transform.position.x;
            _traversedPath = 0;
        }

        public void Update()
        {
            var currentDistance = _car.transform.position.x - _startCarPositionX;
            if (currentDistance > _traversedPath)
                _traversedPath = currentDistance;
        }

        private void CleanUp()
        {
            if (_car != null)
            {
                _car.DriverIsDead -= OnDriverDead;
                Object.Destroy(_car.gameObject);
            }
        }

        private void OnDriverDead()
        {
            Finish();
        }

        public void Start()
        {
            _isPlaying = true;
        }

        private void Finish()
        {
            _meta.FinishGame();
        }


        public void MoveForward()
        {
            _car.Accelerate();
        }

        public void MoveBackward()
        {
            _car.Brake();
        }

        public void ReleasePedal()
        {
            _car.ReleasePedal();
        }
    }
}