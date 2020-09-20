using System.Collections.Generic;
using Common;
using UnityEngine;

namespace UI.Common
{
    /// <summary>
    /// Singleton screen controller. Stores UI screens, manages consistent screens opening and closing.
    /// </summary>
    public class ScreenController : Singleton<ScreenController>
    {
        [SerializeField] private List<BaseScreen> screens;
        [SerializeField] private Canvas canvas;

        private BaseScreen _currentScreen;

        /// <summary>
        /// UI Canvas.
        /// </summary>
        public Canvas Canvas => canvas;

        private void Update()
        {
            if (Input.GetKey(KeyCode.U))
            {
                HideCurrentScreen();
            }
        }

        /// <summary>
        /// Shows the screen of type <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">UI screen type.</typeparam>
        /// <returns>Shown screen instance.</returns>
        public T ShowScreen<T>() where T : BaseScreen
        {
            HideCurrentScreen();

            _currentScreen = screens.Find(s => s.GetType() == typeof(T));
            ShowScreen(_currentScreen);
            return (T) _currentScreen;
        }

        private static void ShowScreen(BaseScreen screen)
        {
            screen.gameObject.SetActive(true);
        }

        private static void HideScreen(BaseScreen screen)
        {
            screen.gameObject.SetActive(false);
        }

        private void HideCurrentScreen()
        {
            if (_currentScreen != null)
            {
                HideScreen(_currentScreen);
                _currentScreen = null;
            }
        }
    }
}