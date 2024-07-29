using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class WeaponBoard : MonoBehaviour
    {
        [SerializeField] private Weapon _origin;
        [SerializeField] private Transform _weaponStartPosition;
        
        [field:SerializeField] public Weapon Weapon { get; set; }
        
        public void CreateNewWeapon()
        {
            Weapon = Instantiate(_origin, _weaponStartPosition.position, _weaponStartPosition.rotation);
        }
    }
}
