﻿using System.Collections.Generic;

namespace Lab4
{
    class Superkey : Item, IUsable
    {
        const int maxCharges = 3;
        private int currentCharges;

        public Superkey()
        {
            currentCharges = maxCharges;
        }

        public void Use(List<Item> inventory)
        {
            currentCharges--;
            if (currentCharges <= 0) { inventory.Remove(this); }
        }
    }
}