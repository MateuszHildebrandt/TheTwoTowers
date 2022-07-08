using Game;
using UnityEngine;
using Zenject;

namespace Elevator
{
    public class ElevatorButton : MonoBehaviour, IInteractable
    {
        [Header("References")]
        [SerializeField] Transform level;
        [Header("Resoureces")]
        [SerializeField] AudioClip clickSound;

        ElevatorManager _elevatorManager;

        [Inject]
        private void Initializer(ElevatorManager elevatorManager)
        {
            _elevatorManager = elevatorManager;
        }

        public void Action()
        {
            _elevatorManager.SetLevel(level);
            AudioSource.PlayClipAtPoint(clickSound, transform.position);
        }
    }
}
