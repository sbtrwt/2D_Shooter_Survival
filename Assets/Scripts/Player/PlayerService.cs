using Shooter2D.Interfaces;
using Shooter2D.Weapon.Bullet;
using UnityEngine;

namespace Shooter2D.Player
{
    public class PlayerService: IObjectPoolHandler<BulletController>
    {
        private PlayerSO playerSO;
        private PlayerController playerController;
        private BulletPool bulletPool;
        public PlayerService(PlayerSO playerSO, BulletSO bulletSO)
        {
            this.playerSO = playerSO;
            bulletPool = new BulletPool(bulletSO.BulletView, bulletSO, this);
            playerController = new PlayerController(playerSO.playerView, bulletPool);
            playerController.Init();
        }
        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();


        public void ReturnItem(BulletController item) => bulletPool.ReturnItem(item);
       
    }
}
