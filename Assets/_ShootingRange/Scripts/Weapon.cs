using System.Collections;
using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [field:SerializeField] public WeaponConfig WeaponConfig { get; private set; }
        [field:SerializeField] private Transform BulletSpawnPoint { get; set; }
        [SerializeField] private Camera _firstPersonCamera;
        
        public Vector3 SpawnPoint => BulletSpawnPoint.position;
        
        private Vector3 _middleCameraPosition = new Vector3(0.5f, 0.5f, 0);
        public bool AllowShoot { get; private set; } = true;

        public void SetParent(Transform target)
        {
            transform.SetParent(target);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        
        public void Shoot()
        {
            Ray ray = _firstPersonCamera.ViewportPointToRay(_middleCameraPosition);
            Projectile currentBullet = Instantiate(WeaponConfig.Bullet, SpawnPoint, Quaternion.identity);
            currentBullet.SetupDamage(WeaponConfig.Damage);
            currentBullet.transform.forward = ray.direction;
            currentBullet.GetComponent<Rigidbody>().
                AddForce(ray.direction * WeaponConfig.ShootForce, ForceMode.Impulse);
            StartCoroutine(ResetShot(WeaponConfig.TimeBetweenShots));
        }
        
        private IEnumerator ResetShot(float timeBetweenShots)
        {
            AllowShoot = false;
            yield return new WaitForSeconds(timeBetweenShots);
            AllowShoot = true;
        }
    }
}