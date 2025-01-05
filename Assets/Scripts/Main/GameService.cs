using Shooter2D.Enemy;
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
        private EnemyService enemyService;
        #endregion

        [Header("ScriptableObjects")]
        #region ScriptableObjects
        [SerializeField] private PlayerSO playerSO;
        [SerializeField] private BulletSO bulletSO;
        [SerializeField] private WeaponSO weaponSO;
        [SerializeField] private EnemySO enemySO;
        #endregion

        [Header("GameObjects")]
        #region GameObjects
        [SerializeField] private Transform weaponContainer;
        [SerializeField] private EnemyView enemyViewPrefab;
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
            enemyService = new EnemyService(enemyViewPrefab, enemySO); 
        }

        private void InjectDependencies()
        {
            weaponService.Init(bulletService);
            playerService.Init(weaponService);

        }
        public void Update()
        {
            enemyService.Update();
        }
    }
}
