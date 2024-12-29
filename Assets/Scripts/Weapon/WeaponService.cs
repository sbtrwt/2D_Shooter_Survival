using Shooter2D.Interfaces;
using Shooter2D.Weapon.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter2D.Weapon
{
    public class WeaponService: IObjectPoolHandler<BulletController>
    {
        private BulletPool bulletPool;
        private WeaponController weaponController;
        public WeaponService( BulletSO bulletSO)
        {
           bulletPool = new BulletPool(bulletSO.BulletView, bulletSO, this);
        }
        public void ReturnBulletToPool(BulletController bulletToReturn) => bulletPool.ReturnItem(bulletToReturn);

        public void ReturnItem(BulletController item) => bulletPool.ReturnItem(item);
        
    }
}
