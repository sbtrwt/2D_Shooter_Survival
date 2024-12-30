
using Shooter2D.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter2D.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private Animator animator;
        [SerializeField] private Animator footAnimator;
        [SerializeField] private Transform gunPoint;

        public PlayerController Controller;
        public Transform GunPoint => gunPoint;
       

        private void Update()
        {
            Controller.Update();
            SetAnimation(Controller.MoveDirection);
           
        }
        private void SetAnimation(Vector2 moveDirection)
        {
            if (moveDirection != Vector2.zero)
            {
                animator.SetFloat("XInput", moveDirection.x);
                animator.SetFloat("YInput", moveDirection.y);

                footAnimator.SetFloat("XInput", moveDirection.x);
                footAnimator.SetFloat("YInput", moveDirection.y);
            }
            else
            {
                
            }
        }
        private void FixedUpdate()
        {
            rb.velocity = Controller.MoveDirection * speed;
        }
    }
}