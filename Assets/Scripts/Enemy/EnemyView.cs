using Shooter2D.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Shooter2D.Enemy
{
    public class EnemyView : MonoBehaviour, IDamageable
    {
        public EnemyController Controller;
        private void Update() => Controller.UpdateMotion();

        private void OnTriggerEnter2D(Collider2D collision) => Controller?.OnEnemyCollided(collision.gameObject);

        public void TakeDamage(float damageToTake) => Controller.TakeDamage(damageToTake);
    }
}