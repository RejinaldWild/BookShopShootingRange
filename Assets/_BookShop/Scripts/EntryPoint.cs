using UnityEngine;

namespace _BookShop.Scripts
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _config;
        [SerializeField] private Player _player;

        private Inventory _inventory;
        private InputController _inputController;
        private Wallet _wallet;
        private MoveController _moveController;
        
        private void Awake()
        {
            _inputController = new InputController();
            _wallet = new Wallet(_config.Money);
            _inventory = new Inventory();
            _player.Construct(_config,_inventory,_wallet);
            _moveController = new MoveController(_inputController, _player);
        }

        private void Update()
        {
            _moveController.Update();
        }

        private void FixedUpdate()
        {
            _moveController.FixedUpdate();
        }
    }
}
