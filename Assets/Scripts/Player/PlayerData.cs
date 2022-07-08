using System;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public int jumpCount;
        public int shotDownObjects;

        public float spread;
        public const float MAX_SPREAD = 70;

        public bool onGround;
        public bool onIce;

        public void ResetData()
        {
            jumpCount = 0;
            shotDownObjects = 0;
            spread = 0;

            onGround = false;
            onIce = false;
        }

        public void ClampSpread(float value) => spread = Mathf.Clamp(value, 0, MAX_SPREAD);
    }
}
