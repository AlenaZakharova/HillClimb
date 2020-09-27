using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class PressButton : Button
    {
        public bool Pressed => _pressed;
        public event Action Press;
        public event Action Release;

        private bool _pressed;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            _pressed = true;
            Press?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            _pressed = false;
            Release?.Invoke();
        }
    }
}