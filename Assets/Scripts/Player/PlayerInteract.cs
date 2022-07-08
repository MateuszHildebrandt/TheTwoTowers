using Game;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInteract : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] LayerMask interactLayer;
        [SerializeField] float distance;

        private PlayerCamera _playerCamera;
        private InputActions _inputActions;

        private void Awake()
        {
            _inputActions.Player.Use.performed += (_) => Use();
        }

        [Inject]
        private void Initializer(PlayerCamera playerCamera, InputActions inputActions)
        {
            _playerCamera = playerCamera;
            _inputActions = inputActions;
        }

        private void Use()
        {
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit hit, distance, interactLayer))
            {
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                    interactable.Action();
            }
        }
    }
}
