using System;
using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class InputController
    {
        public event Action ButtonClicked;

        private readonly float _sensitivity;
        
        private float _rotationX;
        private float _rotationY;

        public InputController(PlayerConfig config)
        {
            _sensitivity = config.Sensitivity;
        }

        public Vector3 GetPosition()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            return new Vector3(x, 0, z).normalized;
        }

        public Vector3 GetRotation()
        {
            _rotationX -= Input.GetAxisRaw("Mouse Y") * _sensitivity;
            _rotationY += Input.GetAxisRaw("Mouse X") * _sensitivity;
            return new Vector3(_rotationX, _rotationY, 0);
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                ButtonClicked?.Invoke();
            }
        }
    }
}
