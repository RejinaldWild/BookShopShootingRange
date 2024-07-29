using UnityEngine;

namespace _ShootingRange.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Rigidbody _rigidbody;
        
        private Inventory _inventory;
        private WeaponBoard _currentBoard;
        private float _speed;
        
        [field: SerializeField] public Transform Hand { get; private set; }

        public void Construct(Inventory inventory)
        {
            _rigidbody.freezeRotation = true;
            _inventory = inventory;
            _speed = _playerConfig.Speed;
        }
        
        public void Move(Vector3 moveDirection)
        {
            _rigidbody.velocity = moveDirection * (_speed * Time.deltaTime);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out WeaponBoard weaponBoard))
            {
                _currentBoard = weaponBoard;
                TakeWeapon(_currentBoard);
            }
        }

        private void TakeWeapon(WeaponBoard currentBoard)
        {
            bool isSameWeapon = _inventory.Weapon == currentBoard.Weapon;
            if (_inventory.HasWeapon)
            {
                _currentBoard.CreateNewWeapon();
                _inventory.RemoveWeapon(_inventory.Weapon);
                _currentBoard.Weapon.SetParent(Hand.transform);
                _inventory.TakeWeapon(_currentBoard.Weapon);
            }
            else if (!isSameWeapon)
            {
                _currentBoard.CreateNewWeapon();
                _currentBoard.Weapon.SetParent(Hand.transform);
                _inventory.TakeWeapon(_currentBoard.Weapon);
            }
        }
    }
}