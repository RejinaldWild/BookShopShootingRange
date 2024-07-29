using UnityEngine;

namespace _BookShop.Scripts
{
    public class InputController
    {
        public Vector3 GetPosition()
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            return new Vector3(x, 0, z).normalized;
        }
    }
}