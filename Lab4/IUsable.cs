using System.Collections.Generic;

namespace Lab4
{
    interface IUsable
    {
        string ItemName { get; }
        int CurrentCharges { get; set; }

        void Use(List<Item> inventory);
    }
}