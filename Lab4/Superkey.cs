using System;
using System.Collections.Generic;

namespace Lab4
{
    class Superkey : Item, IUsable
    {
        const int maxCharges = 3;
        const string itemName = "Superkey";
        private int currentCharges;

        public Superkey()
        {
            currentCharges = maxCharges;
        }

        public string ItemName
        {
            get { return itemName; }
        }

        public int CurrentCharges
        {
            get { return currentCharges; }
            set { currentCharges = value; }
        }

        public void Use(List<Item> inventory)
        {
            currentCharges--;
            if (currentCharges <= 0)
            {
                System.Console.WriteLine($"\nThe {itemName} broke!");
                inventory.Remove(this);
                Console.ReadKey();
            }
        }
    }
}