using UnityEngine;

namespace Game
{
    public class Bullet : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] float destroyTime = 5f;

        private Rigidbody _rigidbody;
        private Rigidbody MyRigibody
        {
            get
            {
                if (_rigidbody == null)
                    _rigidbody = GetComponent<Rigidbody>();
                return _rigidbody;
            }
        }

        private void Start()
        {
            Destroy(gameObject, destroyTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (MyRigibody.velocity.sqrMagnitude > 3f)
            {
                if (collision.gameObject.TryGetComponent(out IKill target))
                    target.Kill();
            }
        }
    }
}
