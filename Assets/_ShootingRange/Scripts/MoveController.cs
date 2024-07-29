using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class MoveController
    {
        public Vector3 MoveDirection { get; private set; }

        private readonly MainCamera _camera;
        private readonly InputController _inputController;
        private readonly Player _player;

        public MoveController(InputController input, MainCamera camera, Player player)
        {
            _inputController = input;
            _camera = camera;
            _player = player;
        }

        public void Update()
        {
            MoveDirection = ((_camera.transform.forward *_inputController.GetPosition().z)
                             + (_camera.transform.right * _inputController.GetPosition().x));
        }
        
        public void FixedUpdate()
        {
            _player.Move(MoveDirection);
        }
    }
}