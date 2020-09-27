using Core;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FinalScreen : BaseScreen
    {
        [SerializeField] private Button menuButton;

        private IMeta _meta;

        public void Setup(IMeta meta)
        {
            _meta = meta;
        }

        private void OnEnable()
        {
            menuButton.onClick.AddListener(MenuButtonOnClick);
        }
        
        private void OnDisable()
        {
            menuButton.onClick.RemoveListener(MenuButtonOnClick);
        }
        
        private void MenuButtonOnClick()
        {
            _meta.GoToMenu();
        }
    }
}