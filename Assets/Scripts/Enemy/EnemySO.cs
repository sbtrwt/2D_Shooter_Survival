using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Enemy
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObjects/EnemySO")]
    public class EnemySO : ScriptableObject
    {
        public float spawnDistance;
        public float initialSpawnRate;
        public float minimumSpawnRate;
        public float difficultyDelta;
        public EnemyData enemyData;
    }
    [Serializable]
    public struct EnemyData
    {
        public int maxHealth;
        public float minimumSpeed;
        public float maximumSpeed;
        public int damageToInflict;
        public int scoreToGrant;
        public float movementDuration;
        public float rotationSpeed;
        public float rotationTolerance;
    }
}
