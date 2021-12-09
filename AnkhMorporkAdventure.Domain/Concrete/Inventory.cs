using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class Inventory
    {
        public Inventory()
        {
            Items = new Dictionary<Item, int>();
        }

        public void AddItem(Item item, int count)
        {
            if (count <= 0)
                return;

            if (Items.ContainsKey(item)) 
            {
                Items[item] += count;
                return;
            }

            Items.Add(item, count);
        }

        public bool GetItem(Item item)
        {
            if (!Items.ContainsKey(item))
                return false;

            if (Items[item] > 1)
            {
                Items[item]--;
                return true;
            }

            Items.Remove(item);
            return true;
        }

        public Dictionary<Item, int> Items { get; private set; }
    }
}