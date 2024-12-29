using Shooter2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter2D.Weapon
{
    public class WeaponController : IFireable
    {
        public bool CanFire => throw new NotImplementedException();

        public void Fire()
        {
            
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }
    }
}
