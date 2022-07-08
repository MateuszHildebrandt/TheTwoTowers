using Game;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IKill
    {
        [Header("References")]
        [SerializeField] Transform spawnPoint;
        [Header("Resources")]
        [SerializeField] PlayerData playerData;

        private InputActions _inputActions;

        private void Awake()
        {
            _inputActions.Player.Enable();

            playerData.ResetData();
        }

        [Inject]
        private void Initializer(InputActions inputActions)
        {
            _inputActions = inputActions;
        }

        public void Kill() => SetSpawnPoint();

        private void SetSpawnPoint() => transform.position = spawnPoint.position;
    }
}
