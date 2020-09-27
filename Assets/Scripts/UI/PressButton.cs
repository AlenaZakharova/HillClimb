using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class PressButton : Button
    {
        public bool Pressed => pressed;
        public event Action Press;
        public event Action Release;

        private bool pressed;

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            pressed = true;
            Press?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            pressed = false;
            Release?.Invoke();
        }
    }
}