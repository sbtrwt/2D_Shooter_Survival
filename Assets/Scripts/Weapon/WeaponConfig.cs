
using UnityEngine;

namespace Shooter2D.Weapon
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Weapon/WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {
        public string WeaponName;
        public float Damage;
        public WeaponType WeaponType;
        public float Range;
        public WeaponView Prefab;
        public Sprite icon;


    }

    public class WeaponFactory
    {
        public WeaponController CreateWeapon(WeaponConfig config)
        {
            WeaponController weaponInstance = new WeaponController(config);
            
            return weaponInstance;

        }
    }
}
