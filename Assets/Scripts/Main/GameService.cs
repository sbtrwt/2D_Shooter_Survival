using Shooter2D.Player;
using Shooter2D.Weapon;
using Shooter2D.Weapon.Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;


namespace Shooter2D
{

    public class GameService : MonoBehaviour
    {
        #region Services
        private PlayerService playerService;
        private WeaponService weaponService;
        private BulletService bulletService;
        //private EnemyService enemyService;
        #endregion

        #region ScriptableObjects
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private BulletSO bulletSO;
        [SerializeField] private WeaponSO weaponSO;
        #endregion

        #region GameObjects
        [SerializeField] private Transform weaponContainer;
        #endregion

        private void Start()
        {
            InitializeServices();
            InjectDependencies();

        }
        private void InitializeServices()
        {
           
            playerService = new PlayerService(playerSO);
            weaponService = new WeaponService(weaponSO, weaponContainer);
            bulletService = new BulletService(bulletSO);
            //enemyService = new EnemyService(enemySO);
        }

        private void InjectDependencies()
        {
            weaponService.Init(bulletService);
            playerService.Init(weaponService);

        }
    }
}
