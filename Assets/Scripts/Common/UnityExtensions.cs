using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    /// <summary>
    /// Helpful Unity classes extensions.
    /// </summary>
    public static class UnityExtensions
    {
        /// <summary>
        /// Applies curve to the object scale.
        /// </summary>
        /// <param name="self">Transform to scale.</param>
        /// <param name="curve">Scale curve.</param>
        /// <returns>Iterator for coroutine.</returns>
        public static IEnumerator Bounce(this Transform self, AnimationCurve curve)
        {
            float elapsed = 0f;
            while (elapsed <= curve[curve.length - 1].time)
            {
                self.localScale = Vector3.one * curve.Evaluate(elapsed);
                elapsed += Time.deltaTime;
                yield return null;
            }

            self.localScale = Vector3.one * curve[curve.length - 1].value;
        }

        /// <summary>
        /// Applies curve to the object color's alpha channel.
        /// </summary>
        /// <param name="self">Graphic to fade.</param>
        /// <param name="curve">Fade curve.</param>
        /// <returns>Iterator for coroutine.</returns>
        public static IEnumerator Fade(this Graphic self, AnimationCurve curve, float multiplier = 1f)
        {
            float elapsed = 0f;
            Color c = self.color;
            while (elapsed <= curve[curve.length - 1].time)
            {

                self.color = new Color(c.r, c.g, c.b, curve.Evaluate(elapsed) * multiplier);
                elapsed += Time.deltaTime;
                yield return null;
            }

            self.color = new Color(c.r, c.g, c.b, curve[curve.length - 1].value * multiplier);
        }

        /// <summary>
        /// Runs a coroutine on the <see cref="target"/> object with the <see cref="action"/>
        /// after <see cref="delay"/> seconds.
        /// </summary>
        /// <param name="target">Object to run a coroutine on.</param>
        /// <param name="delay">Action delay in seconds.</param>
        /// <param name="action">Action to execute after delay.</param>
        /// <returns>Started coroutine.</returns>
        public static Coroutine StartCoroutineWithDelay(this MonoBehaviour target, float delay, Action action)
        {
            return target.StartCoroutine(DelayCoroutine(delay, action));
        }

        /// <summary>
        /// Resizes RetTransform anchors to fit device screen safe area
        /// </summary>
        /// <param name="rectTransform"></param>
        public static void ApplySafeArea(this RectTransform rectTransform)
        {
            Rect safeArea = Screen.safeArea;
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = anchorMin + safeArea.size;
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }

        private static IEnumerator DelayCoroutine(float delay, Action action)
        {
            yield return new WaitForSeconds(delay);

            action.Invoke();
        }
    }
}