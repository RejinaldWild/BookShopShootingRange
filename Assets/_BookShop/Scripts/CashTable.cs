using System.Collections.Generic;
using UnityEngine;

namespace _BookShop.Scripts
{
    public class CashTable : MonoBehaviour
    {
        public IReadOnlyCollection<Book> Books => _books;

        [SerializeField] private List<Book> _books;
    }
}