using UnityEngine;

namespace _BookShop.Scripts
{
    public class Wallet
    {
        public float Money { get; private set; }

        public Wallet(int money)
        {
            Money = money;
        }
        public void Subtract(int amount)
        {
            if (amount > Money)
            {
                Debug.LogError("You cant afford it!");
            }
            else
            {
                Money -= amount;
            }
        }
    }
}