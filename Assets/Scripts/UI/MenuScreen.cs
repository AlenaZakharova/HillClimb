using Core;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuScreen : BaseScreen
    {
        [SerializeField] private Button playButton;

        private IMeta _meta;

        public void Setup(IMeta meta)
        {
            this._meta = meta;
        }

        private void OnEnable()
        {
            playButton.onClick.AddListener(PlayButtonOnClick);
        }
        
        private void OnDisable()
        {
            playButton.onClick.RemoveListener(PlayButtonOnClick);
        }

        private void PlayButtonOnClick()
        {
            _meta.StartGame();
        }
    }
}