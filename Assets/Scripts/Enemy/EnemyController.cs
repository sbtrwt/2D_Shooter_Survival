using Shooter2D.Player;
using System;

using UnityEngine;

namespace Shooter2D.Enemy
{
    public class EnemyController
    {
        // Dependencies:
        private EnemyView enemyView;
        //private EnemyData enemyData;

        // Variables:
        private EnemyState currentEnemyState;
        private float currentHealth;
        private float speed;
        private float movementTimer;
        private Quaternion targetRotation;
        private EnemyService enemyService;
        private EnemySO enemySO;
        public EnemyController(EnemyView enemyPrefab, EnemySO enemySO, EnemyService enemyService)
        {
            enemyView = GameObject.Instantiate(enemyPrefab);
            enemyView.Controller=(this);
            this.enemySO = enemySO;
            this.enemyService = enemyService;
        }

        public void Configure(Vector3 positionToSet, EnemyOrientation enemyOrientation)
        {
            enemyView.transform.position = positionToSet;
            SetEnemyOrientation(enemyOrientation);

            currentEnemyState = EnemyState.Moving;
            currentHealth = enemySO.enemyData.maxHealth;
            speed = UnityEngine.Random.Range(enemySO.enemyData.minimumSpeed, enemySO.enemyData.maximumSpeed);
            movementTimer = enemySO.enemyData.movementDuration;
            enemyView.gameObject.SetActive(true);
        }

        private void SetEnemyOrientation(EnemyOrientation orientation)
        {
            // Rotate the enemy based on its orientation
            switch (orientation)
            {
                case EnemyOrientation.Left:
                    enemyView.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                    break;
                case EnemyOrientation.Right:
                    enemyView.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                    break;
                case EnemyOrientation.Up:
                    enemyView.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    break;
                case EnemyOrientation.Down:
                    enemyView.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    break;
            }
        }

        public void TakeDamage(float damageToTake)
        {
            currentHealth -= damageToTake;
            if (currentHealth <= 0)
                EnemyDestroyed();
        }

        public void UpdateMotion()
        {
            if (currentEnemyState == EnemyState.Moving)
            {
                enemyView.transform.position += enemyView.transform.up * Time.deltaTime * speed;
                movementTimer -= Time.deltaTime;

                if (movementTimer <= 0)
                {
                    SetTargetRotation();
                    movementTimer = enemySO. enemyData.movementDuration;
                }
            }
            else if (currentEnemyState == EnemyState.Rotating)
            {
                enemyView.transform.rotation = Quaternion.RotateTowards(enemyView.transform.rotation, targetRotation, enemySO.enemyData.rotationSpeed * Time.deltaTime);

                if (Quaternion.Angle(enemyView.transform.rotation, targetRotation) < enemySO.enemyData.rotationTolerance)
                    currentEnemyState = EnemyState.Moving;
            }
        }

        private void SetTargetRotation()
        {
            //Vector3 direction = GameService.Instance.GetPlayerService().GetPlayerPosition() - enemyView.transform.position;
            //targetRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f);
            //currentEnemyState = EnemyState.Rotating;
        }

        public void OnEnemyCollided(GameObject collidedGameObject)
        {
            if (collidedGameObject.GetComponent<PlayerView>() != null)
            {
                //GameService.Instance.GetPlayerService().GetPlayerController().TakeDamage(enemySO.enemyData.damageToInflict);
                EnemyDestroyed();
            }
        }

        private void EnemyDestroyed()
        {
            //GameService.Instance.GetUIService().IncrementScore(enemyData.scoreToGrant);
            //GameService.Instance.GetSoundService().PlaySoundEffects(SoundType.EnemyDeath);
            //GameService.Instance.GetVFXService().PlayVFXAtPosition(VFXType.EnemyExplosion, enemyView.transform.position);
            enemyView.gameObject.SetActive(false);
            enemyService.ReturnEnemyToPool(this);
        }

        private enum EnemyState
        {
            Moving,
            Rotating
        }
    }
}
