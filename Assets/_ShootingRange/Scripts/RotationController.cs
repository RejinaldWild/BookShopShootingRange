using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class RotationController
    {
        private readonly InputController _inputController;
        
        private Vector3 _rotation;

        public RotationController(InputController inputController)
        {
            _inputController = inputController;
        }
        
        public Vector3 Rotate()
        {
            _rotation.x = _inputController.GetRotation().x;
            _rotation.y = _inputController.GetRotation().y;
            _rotation.x = Mathf.Clamp(_rotation.x, -60, 60);
            return _rotation;
        }
    }
}