
using Shooter2D.Interfaces;
using UnityEngine;

namespace Shooter2D.Weapon.Bullet
{
    public class BulletController
    {
        private BulletView bulletView;
        private BulletSO bulletSO;
        private Vector2 bulletDirection;
        public BulletController( BulletView bulletView, Transform bulletContainer, BulletSO bulletSO)
        {
            this.bulletView = GameObject.Instantiate(bulletView, bulletContainer);
            this.bulletSO = bulletSO;
            this.bulletView.Controller = this;
        }
        public void ConfigureBullet(Vector2 position, Vector2 direction)
        {
            bulletView.gameObject.SetActive(true);
            bulletView.transform.position = position;
            bulletDirection = direction.normalized;
            //bulletView.transform.rotation = spawnTransform.rotation;
        }
        public void UpdateBulletMotion()
        {
            bulletView.transform.Translate( Time.deltaTime * bulletSO.Speed * bulletDirection);
        }
        public void OnBulletEnteredTrigger(GameObject collidedGameObject)
        {
            if (collidedGameObject.GetComponent<IDamageable>() != null)
            {
                collidedGameObject.GetComponent<IDamageable>().TakeDamage(bulletSO.Damage);
                //GameService.Instance.GetSoundService().PlaySoundEffects(SoundType.BulletHit);
                //GameService.Instance.GetVFXService().PlayVFXAtPosition(VFXType.BulletHitExplosion, bulletView.transform.position);
                bulletView.gameObject.SetActive(false);
                //GameService.Instance.GetPlayerService().ReturnBulletToPool(this);
            }
        }
    }
}
