using Shooter2D.Interfaces;
using Shooter2D.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Weapon.Bullet
{
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletView;
        private Transform bulletContainer;
        private BulletSO bulletSO;
        private IObjectPoolHandler<BulletController> objectPoolHandler;
        public BulletPool(BulletView bulletView, BulletSO bulletSO, IObjectPoolHandler<BulletController> objectPoolHandler)
        {
            this.bulletView = bulletView;

            this.bulletContainer = new GameObject("Bullet Container").transform;
            this.bulletSO = bulletSO;
            this.objectPoolHandler = objectPoolHandler;
        }

        protected override BulletController CreateItem() => new BulletController(bulletView, bulletContainer,bulletSO, objectPoolHandler);
        public BulletController GetBullet()
        {
            BulletController bullet = GetItem();

            return bullet;
        }
    }
}
