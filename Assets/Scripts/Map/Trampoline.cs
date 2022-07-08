using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] AudioClip jumpClip;
    [Header("Setttings")]
    [SerializeField] float bounce = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.IsPlayer())
        {
            if (other.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.velocity = Vector3.up * bounce;
                AudioSource.PlayClipAtPoint(jumpClip, transform.position);
            }
        }
    }
}
