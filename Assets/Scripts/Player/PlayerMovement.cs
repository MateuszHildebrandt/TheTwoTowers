using Game;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Resoureces")]
        [SerializeField] AudioClip jumpSound;
        [SerializeField] PlayerData playerData;
        [SerializeField] CrosshairData crosshairData;
        [Header("Settings")]
        [SerializeField] float walkSpeed = 5f;
        [SerializeField] float airSpeed = 0.5f;
        [Space]
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float groundRadius = 0.4f;
        [SerializeField] float groundDrag = 1;
        [SerializeField] float iceDrag = 1;
        [Space]
        [SerializeField] float jumpStrength = 5f;

        private Rigidbody _rigidbody;
        private CapsuleCollider _capsuleCollider;
        private InputActions _inputActions;

        private Vector2 _direction;      

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _capsuleCollider = GetComponent<CapsuleCollider>();
           
            _inputActions.Player.Jump.performed += (_) => Jump();
        }

        private void Update()
        {
            Input();
            Drag();
            Grounded();
        }

        private void FixedUpdate()
        {
            Move();
            SpeedLimit();
        }

        [Inject]
        private void Initializer(InputActions inputActions)
        {
            _inputActions = inputActions;
        }

        private void Input()
        {
            _direction = _inputActions.Player.Move.ReadValue<Vector2>();            
        }

        private void Drag()
        {
            if(playerData.onGround)
                _rigidbody.drag = playerData.onIce ? iceDrag : groundDrag;
            else
                _rigidbody.drag = 0f;
        }

        private void Grounded() => playerData.onGround = Physics.CheckSphere(_capsuleCollider.bounds.min, groundRadius, groundLayer);

        private void Move()
        {
            if (_direction == Vector2.zero)
                return;

            Vector3 lookDirection = transform.right * _direction.x + transform.forward * _direction.y;

            if (playerData.onGround)
                _rigidbody.AddForce(lookDirection.normalized * walkSpeed, ForceMode.Acceleration);
            else
                _rigidbody.AddForce(lookDirection.normalized * airSpeed, ForceMode.Acceleration);
        }
        
        private void SpeedLimit()
        {
            Vector3 velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

            if(velocity.magnitude > walkSpeed)
            {
                Vector3 limit = velocity.normalized * walkSpeed;
                _rigidbody.velocity = new Vector3(limit.x, _rigidbody.velocity.y, limit.z);
            }
        }

        private void Jump()
        {
            if (playerData.onGround)
            {
                _rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
                playerData.spread = crosshairData.jumpSpread;
                playerData.jumpCount++;
                _rigidbody.drag = 0;

                AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            }
        }
    }
}
