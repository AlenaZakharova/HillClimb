using Configuration;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core
{
    public class Game
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
            if (_car == null)
            {
                _car = Object.Instantiate(_config.CarPrefab, _config.StartPosition, Quaternion.identity);
                _car.Setup(_config);
            }

            _followCamera.SetTarget(_car.transform);
        }

        public void Start()
        {
            _isPlaying = true;

            _car.StartRace();

        }

        public void Update()
        {
        }

       
        private void FinishGame(bool win)
        {
            _meta.FinishGame();

        }

       
    }
}