using Shooter2D.Player;
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
           
        }

        private void InjectDependencies()
        {
            //playerService.Init();
        }
    }
}
