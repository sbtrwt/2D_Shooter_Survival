using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shooter2D.Player
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO")]
    public class PlayerSO : ScriptableObject
    {
        public float speed = 5f;
        public float fireRate = 0.5f;
        public PlayerView playerView;

    }
}
