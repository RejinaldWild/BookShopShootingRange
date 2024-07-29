using UnityEngine;

namespace _ShootingRange.Scripts
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] private Transform _cameraPosition;
        
        private RotationController _rotationController;
        
        public void Construct(RotationController rotationController)
        {
            _rotationController = rotationController;
        }
        
        private void Update()
        {
            transform.position = _cameraPosition.position;
            transform.eulerAngles = _rotationController.Rotate();
        }
    }
}