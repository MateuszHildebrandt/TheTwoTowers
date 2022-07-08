using Game;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform bulletsParent;
        [SerializeField] Transform shotPoint;
        [Header("Resources")]
        [SerializeField] PlayerData playerData;
        [SerializeField] CrosshairData crosshairData;
        [SerializeField] GameObject bulletPrefab;
        [SerializeField] AudioClip shotSound;
        [Header("Settings")]
        [SerializeField] float shootForce = 10f;

        private PlayerCamera _playerCamera;
        private InputActions _inputActions;

        private Vector3 halfXY = new Vector3(0.5f, 0.5f, 0);

        private void Awake()
        {
            _inputActions.Player.Fire.performed += (_) => Shoot();
        }

        [Inject]
        private void Initializer(PlayerCamera playerCamera, InputActions inputActions)
        {
            _playerCamera = playerCamera;
            _inputActions = inputActions;
        }

        private void Shoot()
        {
            Ray middleScreenRay = _playerCamera.GetComponent<Camera>().ViewportPointToRay(halfXY);

            Vector3 targetPoint;
            if (Physics.Raycast(middleScreenRay, out RaycastHit hit))
                targetPoint = hit.point;
            else
                targetPoint = middleScreenRay.GetPoint(100);

            Vector3 direction = targetPoint - shotPoint.position;
            Vector2 randomCircle = 0.05f * playerData.spread * Random.insideUnitCircle;
            direction = direction + (Vector3)randomCircle;

            GameObject go = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity, bulletsParent);
            go.transform.forward = direction.normalized; //Rotate to shoot direction
            go.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

            playerData.spread += (playerData.spread > crosshairData.weaponSpread) ? 0f : crosshairData.weaponSpread - playerData.spread;
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
}
