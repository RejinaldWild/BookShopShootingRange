using UnityEngine;

namespace _ShootingRange.Scripts
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
    public class WeaponConfig : ScriptableObject
    {
        [field: SerializeField] public Projectile Bullet { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float TimeBetweenShots { get; private set; }
        [field: SerializeField] public float ShootForce { get; private set; }
    }
}