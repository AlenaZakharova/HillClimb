using Configuration;
using Model;
using UI;
using UI.Common;
using UnityEngine;

namespace Core
{
    public class Meta : MonoBehaviour, IMeta
    {
        [SerializeField] private GameConfig config;

        [SerializeField] private FollowCamera followCamera;
        
        private Game _game;
        public Player Player { get; private set;}

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            Player = Player.Load();
            
            followCamera.Setup(config);
            _game = new Game(this, config, followCamera);
            _game.Setup();

            var menuScreen = ScreenController.Instance.ShowScreen<MenuScreen>();
            menuScreen.Setup(this);
        }
       
        public void StartGame()
        {
            var gameScreen = ScreenController.Instance.ShowScreen<GameScreen>();
            gameScreen.Setup(this, _game, config);
            _game.Start();
        }

        public void FinishGame()
        {
            var finalScreen = ScreenController.Instance.ShowScreen<FinalScreen>();
            finalScreen.Setup(this);
        }

        public void GoToMenu()
        {
            _game.Setup();
            var menuScreen = ScreenController.Instance.ShowScreen<MenuScreen>();
            menuScreen.Setup(this);
        }
    }
}