using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = "ScriptableObject/CrosshairData")]
    public class CrosshairData : ScriptableObject
    {
        public float weaponSpread = 20;
        public float jumpSpread = 60;
    }
}
