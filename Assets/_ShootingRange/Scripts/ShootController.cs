namespace _ShootingRange.Scripts
{
    public class ShootController
    {
        private readonly Inventory _inventory;
        private readonly InputController _inputController;
        
        public ShootController(InputController input, Inventory inventory)
        {
            _inputController = input;
            _inputController.ButtonClicked += PrepareShoot;
            _inventory = inventory;
        }
        
        public void PrepareShoot()
        {
            if(_inventory.HasWeapon && _inventory.Weapon.AllowShoot)
            {
                _inventory.Weapon.Shoot();
            }
        }

        public void Unsubscribe()
        {
            _inputController.ButtonClicked -= PrepareShoot;
        }
    }
}