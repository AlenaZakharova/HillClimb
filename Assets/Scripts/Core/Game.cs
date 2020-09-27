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

            _car.StartRace();
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