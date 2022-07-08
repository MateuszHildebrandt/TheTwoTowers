using UnityEngine;

namespace Game
{
    public class ParentPlayer : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
                other.transform.SetParent(transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                other.transform.SetParent(null);
                other.transform.localScale = Vector3.one;
            }
        }
    }
}
