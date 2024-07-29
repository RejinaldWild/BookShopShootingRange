using System.Collections.Generic;
using UnityEngine;

namespace _BookShop.Scripts
{
    public class Inventory
    {
        public readonly List<Book> Books = new();
        
        public void AddItem(Book book)
        {
            if (Books.Contains(book))
            {
                Debug.LogError("You have already have this book");
            }
            else
            {
                Books.Add(book);
                Debug.Log("You took a " + book.name);
            }
        }

        public void RemoveItem(Book book)
        {
            if (Books.Contains(book))
            {
                Books.Remove(book);
            }
            else
            {
                Debug.LogError("You dont have " + book.name);
            }
        }
    }
}