using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class Inventory
    {
        public bool HasWeapon => Weapon != null;

        public Weapon Weapon { get; private set; }
        
        public void TakeWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }

        public void RemoveWeapon(Weapon weapon)
        {
            Object.Destroy(weapon.gameObject);
            Weapon = null;
        }
    }
}