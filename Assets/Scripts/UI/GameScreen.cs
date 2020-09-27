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
        private IMeta _meta;
        private GameConfig _config;

        public void Setup(IMeta meta, GameConfig config)
        {
            _meta = meta;
            _config = config;
        }
        
        private void OnEnable()
        {
            finishButton.onClick.AddListener(FinishButtonOnClick);
        }
        
        private void OnDisable()
        {
            finishButton.onClick.RemoveListener(FinishButtonOnClick);
        }

        private void FinishButtonOnClick()
        {
            _meta.FinishGame();
        }
    }
}