using UnityEngine;

namespace _BookShop.Scripts
{
    public class Book : MonoBehaviour
    {
        [field:SerializeField] public int Cost { get; private set; }
    }
}