using AnkhMorporkAdventure.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnkhMorporkAdventure.Domain.Concrete
{
    public class Inventory
    {
        public Dictionary<Item, int> Items { get; private set; }
        
        public Inventory()
        {
            Items = new Dictionary<Item, int>();
        }

        public string AddItem(Item item, int count)
        {
            if (count <= 0 || count > 2)
                return "Incorrect quanitty of items";

            if (Items.ContainsKey(item)) 
            {
                if (Items[item] > 2)
                    return "You backpack can only held 2 numbers of each item";                 
                
                Items[item] += count;                
                return "";
            }

            Items.Add(item, count);
            return "";
        }

        public bool GetItem(string name)
        {
            var item = Items.Keys.FirstOrDefault(i => i.Name == name);

            if (item == null)
                return false;
            
            if (Items[item] > 1)
            {
                Items[item]--;
                return true;
            }

            Items.Remove(item);
            return true;
        }      
    }
}