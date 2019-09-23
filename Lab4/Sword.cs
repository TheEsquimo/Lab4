﻿using System.Collections.Generic;

namespace Lab4
{
    class Sword : Item, IUsable
    {
        private string itemName = "Sword";
        private int currentCharges = 2;

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
            if (currentCharges <= 0) { Destroy(inventory); }
        }

        public void Destroy(List<Item> inventory)
        {
            inventory.Remove(this);
        }
    }
}