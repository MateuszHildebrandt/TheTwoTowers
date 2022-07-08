using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform player;
        [Header("Settings")]
        [SerializeField] float mouseSensitivity = 1f;

        private const float ROTATION_X_LIMIT = 70f;

        private InputActions _inputActions;
        private Vector2 _rotate;
        private float _rotationX, _rotationY;



        private void Update()
        {
            Input();          
        }

        private void FixedUpdate()
        {
            Rotate();
        }

        [Inject]
        private void Initializer(InputActions inputActions)
        {
            _inputActions = inputActions;
        }

        private void Input()
        {
            _rotate = _inputActions.Player.Look.ReadValue<Vector2>();

            if (_rotate == Vector2.zero)
                return;

            _rotationX -= _rotate.y * mouseSensitivity;
            _rotationY += _rotate.x * mouseSensitivity;

            _rotationX = Mathf.Clamp(_rotationX, -ROTATION_X_LIMIT, ROTATION_X_LIMIT);
        }

        private void Rotate()
        {
            if (_rotationX != 0)
                transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);

            if (_rotationY != 0)
                player.localRotation = Quaternion.Euler(0, _rotationY, 0);
        }
    }
}
