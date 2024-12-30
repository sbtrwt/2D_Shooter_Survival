using Shooter2D.Interfaces;
using Shooter2D.Player;
using Shooter2D.Weapon.Bullet;
using System;
using System.Collections.Generic;
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
        public bool CanFire => throw new NotImplementedException();

        public WeaponController(WeaponView weaponView, Transform container, BulletPool bulletPool)
        {
            this.weaponView = GameObject.Instantiate(weaponView, container);
            this.bulletPool = bulletPool;

        }
        public void Fire()
        {
            BulletController bulletToFire = bulletPool.GetBullet();
            bulletToFire.ConfigureBullet(weaponView.GunPoint.position, Vector2.right);
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Rotate(Vector2 direction)
        {
            weaponView.transform.transform.right = direction;
        }
    }
}
