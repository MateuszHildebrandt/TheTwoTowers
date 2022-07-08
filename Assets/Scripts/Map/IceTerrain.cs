using Player;
using UnityEngine;

namespace Game
{
    public class IceTerrain : MonoBehaviour
    {
        [Header("Resources")]
        [SerializeField] PlayerData playerData;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.IsPlayer())
                playerData.onIce = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.IsPlayer())
                playerData.onIce = false;
        }
    }
}
