using UnityEngine;

namespace Game
{
    public class KillPlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.IsPlayer())
            {
                if(collision.gameObject.TryGetComponent(out IKill iKill))
                    iKill.Kill();
            }
        }
    }
}
