using Configuration;
using Core;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private Button finishButton;
        [SerializeField] private PressButton gasButton;
        [SerializeField] private PressButton brakeButton;
        private IMeta _meta;
        private IGame _game;
        private GameConfig _config;

        public void Setup(IMeta meta, IGame game, GameConfig config)
        {
            _meta = meta;
            _game = game;
            _config = config;
        }
        
        private void OnEnable()
        {
            finishButton.onClick.AddListener(FinishButtonOnClick);
            gasButton.Press += OnGasPedalPress;
            brakeButton.Press += OnBrakePedalPress;
            gasButton.Release += OnGasPedalRelease;
            brakeButton.Release += OnBrakePedalRelease;
        }

        private void OnDisable()
        {
            finishButton.onClick.RemoveListener(FinishButtonOnClick);
            gasButton.Press -= OnGasPedalPress;
            brakeButton.Press -= OnBrakePedalPress;
        }

        private void Update()
        {
            if (gasButton.Pressed)
            {
                _game.MoveForward();
            }
            else if (brakeButton.Pressed)
            {
                _game.MoveBackward();
            }
        }

        private void FinishButtonOnClick()
        {
            _meta.FinishGame();
        }

        private void OnGasPedalPress()
        {
            gasButton.image.sprite = _config.GasPedalPressed;
        }

        private void OnBrakePedalPress()
        {
            brakeButton.image.sprite = _config.BrakePedalPressed;
        }

        private void OnGasPedalRelease()
        {
            gasButton.image.sprite = _config.GasPedal;
            _game.ReleasePedal();
        }

        private void OnBrakePedalRelease()
        {
            brakeButton.image.sprite = _config.BrakePedal;
            _game.ReleasePedal();
        }
    }
}