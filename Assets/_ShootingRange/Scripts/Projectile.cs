using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public int Damage { get; private set; }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Target target))
            {
                target.TakeDamage(Damage);
            }
            Destroy(gameObject);
        }

        public void SetupDamage(int damage)
        {
            Damage = damage;
        }
    }
}