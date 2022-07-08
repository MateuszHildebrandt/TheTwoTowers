using UnityEngine;

namespace Level
{
    public class PlatformMoving : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform target;
        [Header("Settings")]
        [SerializeField] float speed;

        private bool _isActive;
        private Vector3 _startPosition;
        private Vector3 _currPosition;

        private void Awake()
        {
            _startPosition = transform.parent.position;
        }

        private void OnEnable()
        {
            RestartPosition();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
                Move();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsPlayer())
                Stop();
        }

        private void FixedUpdate()
        {
            if (_isActive == false)
                return;

            _currPosition = Vector3.MoveTowards(_currPosition, target.position, Time.deltaTime * speed);
            transform.parent.position = _currPosition;

            if (_currPosition == target.position)
                _isActive = false;
        }

        private void Move()
        {
            _isActive = true;
            _currPosition = transform.parent.position;
        }

        private void Stop()
        {
            _isActive = false;
        }

        private void RestartPosition() => transform.parent.position = _startPosition;
    }
}
