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
            weaponView.transform.transform.right = direction;
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
