using Shooter2D.Interfaces;
using Shooter2D.Player;
using Shooter2D.Weapon.Bullet;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Weapon
{
    public class WeaponController : IFireable
    {
        private WeaponView weaponView;
        private BulletPool bulletPool;
        private BulletService bulletService;
        public bool CanFire => throw new NotImplementedException();

        public WeaponController(WeaponView weaponView, Transform container)
        {
            this.weaponView = GameObject.Instantiate(weaponView, container);

        }
        public void Init(BulletService bulletService)
        {
            this.bulletService = bulletService;
            bulletPool = bulletService.BulletPool;
        }
        public void Fire(Vector2 fireDirection)
        {
            BulletController bulletToFire = bulletPool.GetBullet();
            bulletToFire.ConfigureBullet(weaponView.GunPoint.position, fireDirection.normalized);
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Rotate(Vector2 direction)
        {
            // Ensure the direction vector has a magnitude > 0 to avoid errors
            if (direction.sqrMagnitude > 0)
            {
                // Calculate the angle in degrees
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                // Apply the angle to the weapon's rotation
                float xDeg = 0, yDeg = 0;
               
                //if(direction.x < 0 )
                //{
                //    xDeg = 180;
                //}
                //if (direction.y < 0)
                //{
                //    yDeg = 180;
                //}
                weaponView.transform.rotation = Quaternion.Euler(xDeg, yDeg, angle);


            }
        }

        public void Flip()
        {
           
        }
        public void Fire(System.Numerics.Vector2 direction)
        {
            throw new NotImplementedException();
        }
        public void SetParent(Transform parent)
        {
            weaponView.transform.parent = parent;
        }
       
    }
}
