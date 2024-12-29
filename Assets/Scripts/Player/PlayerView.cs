
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter2D
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private PlayerInputAction playerInput;
        Vector2 moveDirection = Vector2.zero;
        private InputAction move;
        private InputAction fire;

        private void Awake()
        {
            playerInput = new PlayerInputAction();
        }
       private void OnEnable()
        {
            playerInput.Enable();
        }

        private void OnDisable()
        {
            playerInput.Disable();
        }

        private void Start()
        {
            move = playerInput.Player.Move;
            fire = playerInput.Player.Fire;
        }

        private void Update()
        {
            moveDirection = move.ReadValue<Vector2>();
            SetAnimation();
            if (fire.triggered)
            {
                Debug.Log("Fire");
            }
        }
        private void SetAnimation()
        {
            if (moveDirection != Vector2.zero)
            {
                animator.SetFloat("XInput", moveDirection.x);
                animator.SetFloat("YInput", moveDirection.y);
                //spriteRenderer.flipX = moveDirection.x < 0;
            }
            else
            {
                
            }
        }
        private void FixedUpdate()
        {
            rb.velocity = moveDirection * speed;
        }
    }
}