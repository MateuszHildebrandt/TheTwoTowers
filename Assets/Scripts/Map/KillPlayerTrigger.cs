using UnityEngine;

namespace Game
{
    public class KillPlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                if (other.gameObject.TryGetComponent(out IKill iKill))
                    iKill.Kill();
            }
        }
    }
}
