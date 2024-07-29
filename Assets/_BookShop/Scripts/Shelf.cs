using UnityEngine;

namespace _BookShop.Scripts
{
    public class Shelf : MonoBehaviour
    {
        [field:SerializeField]public Book Book { get; private set; }
    }
}