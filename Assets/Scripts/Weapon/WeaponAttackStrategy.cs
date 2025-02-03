

using UnityEngine;

namespace Shooter2D.Weapon
{
    public abstract class WeaponAttackStrategy : ScriptableObject
    {
        public abstract void Execute(Vector3 target, GameObject effectPrefab);
    }

    [CreateAssetMenu(fileName = "AoEStrategy", menuName = "Weapon/AttackStrategy/AoEStrategy")]
    public class AoSStrategy : WeaponAttackStrategy
    {
        public override void Execute(Vector3 target, GameObject effectPrefab)
        {
            Debug.Log("AoE Attack");
            GameObject effect = Instantiate(effectPrefab, target, Quaternion.identity);

            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(effect, ps.main.duration);
            }
            else
            {
                Destroy(effect, 5f);
            }
        }
    }
}