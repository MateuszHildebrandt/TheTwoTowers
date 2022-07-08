using UnityEngine;

namespace Level
{
    public class TriggerTarget : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] TargetLevel targetLevel;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
                targetLevel.Setup();
        }
    }
}
