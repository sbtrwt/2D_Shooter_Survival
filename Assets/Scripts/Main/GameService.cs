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
        //private EnemyService enemyService;
        #endregion

        #region ScriptableObjects
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private BulletSO bulletSO;
        #endregion
        private void Start()
        {
            InitializeServices();
            InjectDependencies();

        }
        private void InitializeServices()
        {
           
            playerService = new PlayerService(playerSO, bulletSO);
            weaponService = new WeaponService(bulletSO);
            //enemyService = new EnemyService(enemySO);
        }

        private void InjectDependencies()
        {
            playerService.Init(weaponService);
        }
    }
}
