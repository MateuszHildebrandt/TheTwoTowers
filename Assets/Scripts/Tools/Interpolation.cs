using System;
using System.Collections;
using UnityEngine;

namespace Tools
{
    public static class Interpolation
    {
        public static IEnumerator Lerp(float start, float end, float duration, Action<float> onChange)
        {
            WaitForEndOfFrame wait = new WaitForEndOfFrame();
            float elapsedTime = 0;
            float current = start;

            while (current != end)
            {
                yield return wait;
                elapsedTime += Time.deltaTime;
                current = Mathf.Lerp(start, end, elapsedTime / duration);
                onChange?.Invoke(current);
            }
        }
    }
}
