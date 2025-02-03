
using UnityEngine;

namespace Shooter2D.Weapon
{
    public abstract class WeaponBase : IWeapon
    {
        protected WeaponConfig weaponConfig;
        public virtual void Equip()
        {
            Debug.Log("Equipping weapon: " + weaponConfig.WeaponName);
        }

        public virtual void Initialize(WeaponConfig weaponConfig)
        {
            this.weaponConfig  = weaponConfig; 
        }

        public virtual void Unequip()
        {
            Debug.Log("Unequipping weapon: " + weaponConfig.WeaponName);
        }

        public abstract void Use();
        
    }
    
}
