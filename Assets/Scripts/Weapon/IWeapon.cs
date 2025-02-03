namespace Shooter2D.Weapon
{
    public interface IWeapon
    {
        void Initialize(WeaponConfig weaponConfig);
        void Equip();
        void Unequip();
        void Use();
    }

    public enum WeaponType 
    { 
    }
    
}
