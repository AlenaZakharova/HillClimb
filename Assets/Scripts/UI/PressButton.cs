using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool Pressed => _pressed;
        public event Action Press;
        public event Action Release;

        private bool _pressed;

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
            Press?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
            Release?.Invoke();
        }
    }
}