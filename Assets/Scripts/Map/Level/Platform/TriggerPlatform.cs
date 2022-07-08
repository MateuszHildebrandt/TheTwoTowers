using UnityEngine;

namespace Level
{
    public class TriggerPlatform : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] PlatformLevel platformLevel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
                platformLevel.Setup();
        }
    }
}
