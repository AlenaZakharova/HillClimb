using Configuration;
using Core;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameScreen : BaseScreen
    {
        [SerializeField] private Text distanceText;
        [SerializeField] private Button finishButton;
        [SerializeField] private PressButton gasButton;
        [SerializeField] private PressButton brakeButton;
        [SerializeField] private Image gasButtonImage;
        [SerializeField] private Image brakeButtonImage;
        private IMeta _meta;
        private IGame _game;
        private GameConfig _config;

        public void Setup(IMeta meta, IGame game, GameConfig config)
        {
            _meta = meta;
            _game = game;
            _config = config;
            distanceText.text = "0";
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
            gasButton.Release -= OnGasPedalRelease;
            brakeButton.Release -= OnBrakePedalRelease;
        }

        private void Update()
        {
            distanceText.text = _game.TraversedPath.ToString();
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
            gasButtonImage.sprite = _config.GasPedalPressed;
        }

        private void OnBrakePedalPress()
        {
            brakeButtonImage.sprite = _config.BrakePedalPressed;
        }

        private void OnGasPedalRelease()
        {
            gasButtonImage.sprite = _config.GasPedal;
            _game.ReleasePedal();
        }

        private void OnBrakePedalRelease()
        {
            brakeButtonImage.sprite = _config.BrakePedal;
            _game.ReleasePedal();
        }
    }
}