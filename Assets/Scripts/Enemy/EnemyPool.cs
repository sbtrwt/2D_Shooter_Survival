using Shooter2D.Enemy;
using Shooter2D.Utilities;
using Shooter2D.Weapon.Bullet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyView enemyPrefab;
        private Transform enemytContainer;
        private EnemySO enemySO;
        private EnemyService enemyService;

        public EnemyPool(EnemyView enemyPrefab, EnemySO enemySO, EnemyService enemyService)
        {
            this.enemyPrefab = enemyPrefab;
            this.enemySO = enemySO;
            this.enemyService = enemyService;
        }

        protected override EnemyController CreateItem() => new EnemyController(enemyPrefab, enemySO,enemyService);

        public EnemyController GetEnemy()
        {
            EnemyController bullet = GetItem();

            return bullet;
        }
    }
}
