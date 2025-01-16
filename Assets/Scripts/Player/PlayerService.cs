using Shooter2D.Interfaces;
using Shooter2D.Weapon;
using Shooter2D.Weapon.Bullet;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter2D.Player
{
    public class PlayerService 
    {
        private PlayerSO playerSO;
        private PlayerController playerController;
       
        private WeaponService weaponService;
        private List<WeaponController> weaponControllers = new List<WeaponController>();
        private int activeWeaponIndex = 0;
        public PlayerService(PlayerSO playerSO)
        {
            this.playerSO = playerSO;
          
            playerController = new PlayerController(playerSO.playerView, this);
            playerController.Init();
            
            //AddWeapon(new )
        }
        public void Init(WeaponService weaponService)
        {
            this.weaponService = weaponService;
            weaponControllers = weaponService.GetWeapons();
            SetWeaponParent();
        }
        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();


      
        public void AddWeapon(WeaponController weaponController)
        {
            weaponControllers.Add(weaponController);
        }

        public WeaponController GetActiveWeapon()
        {
            return weaponControllers[activeWeaponIndex];
        }
        public void SetWeaponParent()
        {
            foreach (var weapon in weaponControllers)
            {
                weapon.SetParent(playerController.GetGunHolder());
            }
        }
        public void SwitchWeapon()
        {
            activeWeaponIndex = (activeWeaponIndex + 1) % weaponControllers.Count;
            Debug.Log($"Switched to weapon: {activeWeaponIndex}");
        }

    }
}
