using Shooter2D.Weapon;
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
        private InputAction switchWeapon;

        private float speed = 1f;
        private PlayerService playerService;
        public Vector2 MoveDirection => moveDirection;
        public PlayerController(PlayerView playerView, PlayerService playerService)
        {
            this.playerView = GameObject.Instantiate(playerView);
            this.playerView.Controller = this;
            this.playerService = playerService;

            playerInput = new PlayerInputAction();
            playerInput.Enable();
        }
        public void Init()
        {
            move = playerInput.Player.Move;
            fire = playerInput.Player.Fire;
            //switchWeapon = playerInput.Player.SwitchWeapon;

            fire.performed += ctx => FireWeapon();
            //switchWeapon.performed += ctx => playerService.SwitchWeapon();
        }
        public void Update()
        {
            moveDirection = move.ReadValue<Vector2>();
            if (currentDirection != moveDirection && moveDirection != Vector2.zero)
            {
                currentDirection = moveDirection;
                playerService.GetActiveWeapon().Rotate(currentDirection);
            }
            
        }
        public Vector3 GetPlayerPosition() => playerView != null ? playerView.transform.position : default;
       
        public void FireWeapon()
        {
            WeaponController activeWeapon = playerService.GetActiveWeapon();
            if (activeWeapon != null)
            {
                activeWeapon.Fire(currentDirection);
            }
        }
        public Transform GetGunHolder() => playerView.GunHolder;
        ~PlayerController()
        {
            playerInput.Disable();
        }
    }
}
