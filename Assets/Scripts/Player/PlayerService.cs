using Shooter2D.Weapon.Bullet;
using UnityEngine;

namespace Shooter2D.Player
{
    public class PlayerService
    {
        private PlayerSO playerSO;
        private PlayerController playerController;
        private BulletPool bulletPool;
        public PlayerService(PlayerSO playerSO, BulletSO bulletSO)
        {
            this.playerSO = playerSO;
            bulletPool = new BulletPool(bulletSO.BulletView, bulletSO);
            playerController = new PlayerController(playerSO.playerView, bulletPool);
            playerController.Init();
        }
        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();

        public void ReturnBulletToPool(BulletController bulletToReturn) => bulletPool.ReturnItem(bulletToReturn);
    }
}
