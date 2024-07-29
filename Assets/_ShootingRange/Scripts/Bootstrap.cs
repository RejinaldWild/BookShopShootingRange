using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class Bootstrap: MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private MainCamera _camera;
        [SerializeField] private PlayerConfig _playerConfig;
        
        private InputController _inputController;
        private RotationController _rotationController;
        private MoveController _moveController;
        private ShootController _shootController;
        private Inventory _inventory;

        private void Awake()
        {
            _inputController = new InputController(_playerConfig);
            _rotationController = new RotationController(_inputController);
            _camera.Construct(_rotationController);
            _moveController = new MoveController(_inputController, _camera,_player);
            _inventory = new Inventory();
            _shootController = new ShootController(_inputController, _inventory);
            _player.Construct(_inventory);
        }

        private void Update()
        {
            _moveController.Update();
            _inputController.Update();
        }

        private void OnDestroy()
        {
            _shootController.Unsubscribe();
            StopAllCoroutines();
        }

        private void FixedUpdate()
        {
            _moveController.FixedUpdate();
        }
    }
}