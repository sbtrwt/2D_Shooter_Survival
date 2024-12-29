using Shooter2D.Weapon.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Shooter2D.Player
{
    public class PlayerController
    {   
        private PlayerView playerView;
        private PlayerInputAction playerInput;
        Vector2 moveDirection = Vector2.zero;
        Vector2 currentDirection = Vector2.right;
        private InputAction move;
        private InputAction fire;
        private float speed = 1f;
        private BulletPool bulletPool;
        public Vector2 MoveDirection => moveDirection;
        public PlayerController(PlayerView playerView, BulletPool bulletPool)
        {
            this.playerView = GameObject.Instantiate(playerView);
            this.playerView.Controller = this;
            playerInput = new PlayerInputAction();
            playerInput.Enable();
            this.bulletPool = bulletPool;
        }
        public void Init()
        {

            move = playerInput.Player.Move;
            fire = playerInput.Player.Fire;
            fire.performed += ctx => StartFiring(ctx);
            fire.canceled += ctx => StopFiring(ctx);
        }
        public void Update()
        {
            moveDirection = move.ReadValue<Vector2>();
            if (currentDirection != moveDirection && moveDirection != Vector2.zero)
            {
                currentDirection = moveDirection;
            }
            //if(fire.IsPressed())
            //{
            //    Debug.Log("Fire");  
            //    FireWeapon();
            //}
            //if (fire)
            //{
            //    Debug.Log("Fire");
            //    FireWeapon();
            //}
        }
        public Vector3 GetPlayerPosition() => playerView != null ? playerView.transform.position : default;
        public void FireWeapon()
        {
            Vector2 position = playerView.GunPoint.position;
            FireBulletAtPosition(position, currentDirection);
        }
        void StartFiring(InputAction.CallbackContext context)
        {
            Debug.Log("Firing started!");
            FireWeapon();
            // Add logic for continuous firing or initiating an attack
        }

        void StopFiring(InputAction.CallbackContext context)
        {
            Debug.Log("Firing stopped!");
            // Add logic for stopping an attack or reloading
        }
        private void FireBulletAtPosition(Vector3 fireLocation, Vector2 direction)
        {
            BulletController bulletToFire = bulletPool.GetBullet();
            Debug.Log(direction);
            bulletToFire.ConfigureBullet(fireLocation, direction);
           
        }
        ~PlayerController()
        {
            playerInput.Disable();
        }
    }
}
