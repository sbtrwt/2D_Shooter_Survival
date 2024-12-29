using UnityEngine;

namespace Shooter2D.Interfaces
{
    public interface IBullet
    {
        public void UpdateBulletMotion();

        public void OnBulletEnteredTrigger(GameObject collidedObject);
    }
}
