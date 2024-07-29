using UnityEngine;

namespace _BookShop.Scripts
{
    public class MainCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        void Update()
        {
            transform.LookAt(_target);
        }
    }
}
