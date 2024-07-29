using System.Collections.Generic;
using UnityEngine;

namespace _BookShop.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private CashTable _cashTable;
        [SerializeField] private List<Shelf> _shelves;
        [SerializeField] private Rigidbody _rigidbody;
        
        private PlayerConfig _config;
        private Wallet _wallet;
        private Inventory _inventory;
        private float _speed;
        
        public void Construct(PlayerConfig config, Inventory inventory, Wallet wallet)
        {
            _config = config;
            _inventory = inventory;
            _wallet = wallet;
            _speed = _config.Speed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.TryGetComponent(out Shelf shelf))
            {
                _inventory.AddItem(shelf.Book);
            }

            if(collision.transform.TryGetComponent(out CashTable cashTable))
            {
                Pay();
            }
        }

        private void Pay()
        {
            foreach (Book book in _cashTable.Books)
            {
                if (_wallet.Money >= book.Cost && _inventory.Books.Contains(book))
                {
                    _wallet.Subtract(book.Cost);
                    _inventory.RemoveItem(book);
                    Debug.Log("Now you have got " + _wallet.Money + "$");
                }
                else if (_wallet.Money < book.Cost && _inventory.Books.Contains(book))
                {
                    Debug.Log("You do not have enough money to buy it");
                }
            }

            Debug.Log("You do not have any book in your inventory to buy");
        }

        public void Move(Vector3 delta)
        {
            _rigidbody.velocity = delta * (_speed * Time.deltaTime);
        }
    }
}